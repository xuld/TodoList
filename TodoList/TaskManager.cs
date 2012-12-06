using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Xuld.TodoList {

    /// <summary>
    /// 表示一个任务管理器。
    /// </summary>
    public static class TaskManager {

        /// <summary>
        /// 时间到的任务列表。
        /// </summary>
        static List<TaskEntry> _currentTask;

        /// <summary>
        /// 时间到的任务列表。
        /// </summary>
        static List<TaskEntry> _delayedTask;

        /// <summary>
        /// 等待执行的任务。
        /// </summary>
        static TaskList _tasks = new TaskList();

        /// <summary>
        /// 读取指定的任务字符串。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string LoadTaskString(string name) {
            string path = Path.Combine(AppManager.DataFolder, name + ".txt");
            return File.Exists(path) ? File.ReadAllText(path) : String.Empty;
        }

        /// <summary>
        /// 保存指定的任务字符串。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SaveTaskString(string name, string value) {
            string path = Path.Combine(AppManager.DataFolder, name + ".txt");
            Directory.CreateDirectory(AppManager.DataFolder);
            File.WriteAllText(path, value);
        }

        /// <summary>
        /// 获取当前时间到的任务字符串。
        /// </summary>
        public static string CurrentTaskString {
            get {
                if (_currentTask == null) {
                    return String.Empty;
                }

                StringBuilder sb = new StringBuilder();
                foreach (TaskEntry task in _currentTask) {
                    sb.AppendLine(task.ToString());
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 重新分析任务列表。
        /// </summary>
        public static void RebuildTaskList() {
            TaskList todo = new TaskList();
            TaskList plan = new TaskList();
            TaskList done = new TaskList();

            todo.Load(AppManager.Todo);
            plan.Load(AppManager.Plan);
            done.Load(AppManager.Done);

            bool needSave = false;

            // 重新生成任务列表。
            _tasks.Clear();

            // 如果当前有已到时的任务，则先清空并放入已完成的列表。
            if (_currentTask != null) {
                foreach (TaskEntry task in _currentTask) {

                    // 如果此任务不是即时的，放到已做的列表，然后从要做的列表删除。
                    if (task.NeedRepeat) {

                        if(task.UpdateDateTime())
                            _tasks.Add(task);

                        // 定时的任务，重新生成新的时间。
                    } else {

                        // 删除已完成的任务。
                        todo.Remove(task);

                        needSave = true;
                        done.AddFirst(task);

                    }
                }
                _currentTask = null;
            }


            // 如果有延时的提醒，继续加入列表。
            if (_delayedTask != null) {
                foreach (TaskEntry task in _delayedTask) {
                    _tasks.Add(task);
                }

                _delayedTask = null;
            }

            //if (LoadTaskString(AppManager.Todo).Length > 0) {
            //    _tasks.Add(new TaskEntry() {
            //        Message = "测试 @12:45",
            //        DateTime = DateTime.Now.AddSeconds(3)
            //    });
            //}

            // 预解析 todo 列表。
            for (LinkedListNode<TaskEntry> node = todo.First; node != null; node = node.Next) {
                node.Value.NeedRepeat = false;
                if (node.Value.UpdateDateTime()) {
                    _tasks.Add(node.Value);
                }
            }

            // 预解析 plan 列表。
            for (LinkedListNode<TaskEntry> node = plan.First; node != null; node = node.Next) {
                node.Value.NeedRepeat = true;
                if (node.Value.UpdateDateTime()) {
                    _tasks.Add(node.Value);
                }
            }

            if (needSave) {
                todo.Save(AppManager.Todo);
                plan.Save(AppManager.Plan);
                done.Save(AppManager.Done);
            }

        }

        /// <summary>
        /// 检查当前是否有需要提醒的时间。
        /// </summary>
        public static void Check() {

            if (_tasks.Count > 0) {

                AppManager.Disabled = true;

                DateTime now = DateTime.Now;

                _currentTask = null;

                // 对任务列表进行遍历。
                for (LinkedListNode<TaskEntry> taskNode = _tasks.First; ; ) {

                    // 如果找到已过时的项，则准备提醒此项。
                    if (taskNode.Value.DateTime <= now) {

                        taskNode.Value.SetDelayInfo(now);

                        if (_currentTask == null) {
                            _currentTask = new List<TaskEntry>();
                        }

                        _currentTask.Add(taskNode.Value);

                        LinkedListNode<TaskEntry> t = taskNode.Next;

                        _tasks.Remove(taskNode);

                        if (t == null) {
                            break;
                        }

                        taskNode = t;

                    } else {
                        break;
                    }

                }

                if (_currentTask != null) {
                    AppManager.ShowMainForm(true);
                }


                AppManager.Disabled = false;
            }

        }

        /// <summary>
        /// 延时当前时间到的任务的提醒时间。
        /// </summary>
        /// <param name="miniutes"></param>
        public static void DelayCurrentTask(int miniutes) {

            if (_currentTask != null) {

                _delayedTask = _currentTask;

                foreach (TaskEntry task in _delayedTask) {
                    task.DateTime = DateTime.Now.AddMinutes(miniutes);
                 //   task.DateTime = DateTime.Now.AddSeconds(3);
                    task.RepeatCount++;
                }

                _currentTask = null;

            }

        }

        /// <summary>
        /// 表示一个任务列表。
        /// </summary>
        sealed class TaskList : LinkedList<TaskEntry> {

            /// <summary>
            /// 在适合位置插入一个任务，此任务会根据时间顺序排序。
            /// </summary>
            /// <param name="task"></param>
            public void Add(TaskEntry task) {

                for (var node = First; node != null; node = node.Next) {
                    if (node.Value.DateTime <= task.DateTime) {
                        AddAfter(node, task);
                        return;
                    }
                }



                AddFirst(task);
            }

            public new void Remove(TaskEntry task) {
                for (var node = First; node != null; node = node.Next) {
                    if (node.Value.Message == task.Message) {
                        base.Remove(node);
                        return;
                    }
                }
            }

            public override string ToString() {
                StringBuilder sb = new StringBuilder();
                foreach (TaskEntry task in this) {
                    sb.AppendLine(task.Message);
                }

                return sb.ToString();
            }

            public void Load(string name) {
                string value = LoadTaskString(name);

                string[] lines = value.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines) {

                    TaskEntry task = new TaskEntry() {
                        Message = line
                    };

                    AddLast(task);

                }

            }

            public void Save(string name) {
                SaveTaskString(name, ToString());
            }

        }

        /// <summary>
        /// 表示一个任务。
        /// </summary>
        sealed class TaskEntry : IComparable<TaskEntry> {

            /// <summary>
            /// 任务的内容。
            /// </summary>
            public string Message {
                get;
                set;
            }

            public bool NeedRepeat {
                get;
                set;
            }

            /// <summary>
            /// 任务最近的具体提醒时间。
            /// </summary>
            public DateTime DateTime {
                get;
                set;
            }

            ///// <summary>
            ///// 任务的重复提醒信息。
            ///// </summary>
            //public RepeatInfo RepeatInfo {
            //    get;
            //    set;
            //}

            /// <summary>
            /// 任务的重复提醒的次数。 -1 表示无限地延时。
            /// </summary>
            public int RepeatCount {
                get;
                set;
            }

            string delayedInfo;

            public void SetDelayInfo(DateTime now) {
                TimeSpan span = now - DateTime;
                if (span.TotalMinutes < 1) {
                    return;
                }

                if (span.TotalDays >= 1) {
                    delayedInfo = "(已过期 " + Math.Floor(span.TotalDays) + " 天)";
                } else if (span.TotalHours >= 1) {
                    delayedInfo = "(已过期 " + Math.Floor(span.TotalHours) + " 小时)";
                } else {
                    delayedInfo = "(已过期 " + Math.Floor(span.TotalMinutes) + " 分钟)";
                }

            }

            /// <summary>
            /// 从 Message 中提取下次的提醒时间。
            /// </summary>
            public bool UpdateDateTime() {
                int left = Message.IndexOf('@');

                // 如果没有 @，则不提醒。
                if (left < 0) {
                    return false;
                }

                left++;

                // 先尝试读取一个数字。
                int number = ReadNumber(Message, ref left), hour, miniute;

                DateTime now = DateTime.Now;

                bool needRepeat = NeedRepeat;

                try {

                    // 如果确实是数字。
                    if (number > 0) {

                        // 12 分
                        if (ReadChar(Message, ref left, '分')) {

                            // number 分

                            DateTime = now.AddMinutes(number);

                            // 12 小时
                        } else if (ReadChar(Message, ref left, '小') && ReadChar(Message, ref left, '时')) {

                            // number 小时

                            DateTime = now.AddHours(number);

                            // 12 号 13:00
                        } else if (ReadChar(Message, ref left, '号') || ReadChar(Message, ref left, '日')) {
                            left++;
                            if (!ReadTime(Message, ref left, out hour, out miniute)) {
                                return false;
                            }

                            // number 号 hour:miniute

                            DateTime = new DateTime(now.Year, now.Month, number, hour, miniute, 0);

                            // 如果是定时任务，推迟到最近的时间。
                            if (needRepeat && now > DateTime) {
                                DateTime = DateTime.AddMonths(1);
                            }

                            // 13:00 或 12/3 13:00 或 12月3日 13:00
                        } else {
                            left++;
                            int day = ReadNumber(Message, ref left);

                            if (day < 0) {
                                return false;
                            }

                            if (left < Message.Length && !char.IsDigit(Message, left)) {
                                left++;
                            }

                            // 12/3 13:00 
                            if (ReadTime(Message, ref left, out hour, out miniute)) {

                                // number/day hour:miniute

                                DateTime = new DateTime(now.Year, number, day, hour, miniute, 0);

                                // 如果是月份相同的，则指当前月。否则推迟到最近的那个月份。
                                if (needRepeat && now > DateTime) {
                                    DateTime = DateTime.AddYears(1);
                                }

                            } else {
                                // number:day

                                DateTime = new DateTime(now.Year, now.Month, now.Day, number, day, 0);

                                // 如果是月份相同的，则指当前月。否则推迟到最近的那个月份。
                                if (needRepeat && now > DateTime) {
                                    DateTime = DateTime.AddDays(1);
                                }


                            }


                        }

                        // 12/3 13:00

                    } else if ((ReadChar(Message, ref left, '星') && ReadChar(Message, ref left, '期')) || (ReadChar(Message, ref left, '礼') && ReadChar(Message, ref left, '拜')) || ReadChar(Message, ref left, '周') || ReadChar(Message, ref left, '工')) {

                        byte week = 0;

                        // 周末 hour:miniute
                        if (ReadChar(Message, ref left, '作') && ReadChar(Message, ref left, '日')) {
                            week = (1 << 1) | (1 << 2) | (1 << 3) | (1 << 4) | (1 << 5);
                        } else if (ReadChar(Message, ref left, '末')) {
                            week = (1 << 6) | (1 << 0);
                            // 星期一 hour:miniute
                        } else {

                            while (true) {

                                if (ReadChar(Message, ref left, '一')) {
                                    week |= (1 << 1);

                                } else if (ReadChar(Message, ref left, '二')) {
                                    week |= (1 << 2);

                                } else if (ReadChar(Message, ref left, '三')) {
                                    week |= (1 << 3);

                                } else if (ReadChar(Message, ref left, '四')) {
                                    week |= (1 << 4);

                                } else if (ReadChar(Message, ref left, '五')) {
                                    week |= (1 << 5);

                                } else if (ReadChar(Message, ref left, '六')) {
                                    week |= (1 << 6);

                                } else if (ReadChar(Message, ref left, '天') || ReadChar(Message, ref left, '日')) {
                                    week |= (1 << 0);

                                } else {
                                    break;
                                }
                            }
                        }

                        if (week == 0 || !ReadTime(Message, ref left, out hour, out miniute)) {
                            return false;
                        }

                        // 星期 week hour:minute

                        DateTime = new DateTime(now.Year, now.Month, now.Day, hour, miniute, 0);

                        // 如果今天满足要求，则使用此时间。
                        if (((week >> (int)DateTime.DayOfWeek) & 1) == 1) {

                            // 如果时间已过。
                            if (now > DateTime) {
                                DateTime = DateTime.AddDays(7);
                            }
                        } else {

                            // 不需要重复，则在本星期找到合适的时间点。
                            do {
                                // 获取明天。
                                DateTime = DateTime.AddDays(1);

                            } while (((week >> (int)now.DayOfWeek) & 1) == 0);

                        }

                    } else {
                        return false;
                    }

                } catch (ArgumentOutOfRangeException) {
                    return false;
                }


                return true;
            }

            static void SkipWhitespace(string message, ref int left) {
                while (left < message.Length && char.IsWhiteSpace(message, left))
                    left++;
            }

            static int ReadNumber(string message, ref int left) {
                SkipWhitespace(message, ref left);
                int value = -1;
                if (left < message.Length && char.IsDigit(message, left)) {
                    value =message[left++] - '0';
                    while (left < message.Length && char.IsDigit(message, left)) {
                        value = value * 10 + (message[left++] - '0');
                    }
                }

                return value;
            }

            static bool ReadTime(string message, ref int left, out int hour, out int miniute) {
                hour = ReadNumber(message, ref left);
                miniute = 0;
                if (ReadChar(message, ref left, ':') || ReadChar(message, ref left, '：') || ReadChar(message, ref left, '点')) {
                    miniute = ReadNumber(message, ref left);

                    if (miniute >= 0) {
                        return true;
                    }
                }

                return false;
            }

            static bool ReadChar(string message, ref int left, char value) {
                SkipWhitespace(message, ref left);
                if (left < message.Length && message[left] == value) {
                    left++;
                    return true;
                }

                return false;
            }

            public int CompareTo(TaskEntry other) {
                return DateTime.CompareTo(other.DateTime);
            }

            public override string ToString() {
                return Message + delayedInfo;
            }
        }

        sealed class RepeatInfo {

            /// <summary>
            /// 任务的重复提醒时间。
            /// </summary>
            public int Minute {
                get;
                set;
            }

            /// <summary>
            /// 任务的重复提醒时间。
            /// </summary>
            public int Hour {
                get;
                set;
            }

            /// <summary>
            /// 任务的重复提醒时间。
            /// </summary>
            public int Args {
                get;
                set;
            }

            /// <summary>
            /// 任务的重复提醒单位。
            /// </summary>
            public RepeatInfoUnit Unit {
                get;
                set;
            }

            /// <summary>
            /// 获取和当前重复信息最近的时间。
            /// </summary>
            public DateTime NextDateTime {
                get {
                    DateTime now = DateTime.Now;

                    switch (Unit) {
                        case RepeatInfoUnit.Week:

                            // 如果今天是符合要求的，判断小时是否已经过了。
                            if (((Args >> (int)now.DayOfWeek) & 1) == 1 && (now.Hour < Hour || (now.Hour == Hour && now.Minute < Minute))) {
                                return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);
                            }

                            do {
                                // 获取明天。
                                now = now.AddDays(1);

                                // 如果 Args 里的第 x 位为 1
                            } while (((Args >> (int)now.DayOfWeek) & 1) == 0);

                            return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);

                        case RepeatInfoUnit.Day:

                            // 如果今天是符合要求的，判断小时是否已经过了。
                            if ((now.Hour < Hour || (now.Hour == Hour && now.Minute < Minute))) {
                                return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);
                            }

                            now = now.AddDays(1);

                            return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);

                        case RepeatInfoUnit.Hour:

                            // 如果今天是符合要求的，判断小时是否已经过了。
                            if (now.Minute < Minute) {
                                now = now.AddHours(1);
                            }

                            return new DateTime(now.Year, now.Month, now.Day, now.Hour, Minute, 0);

                        case RepeatInfoUnit.Month:

                            // 正好是今天。
                            if (now.Day == Args) {
                                if (now.Hour < Hour || (now.Hour == Hour && now.Minute < Minute)) {
                                    return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);
                                }
                            }

                            // 如果今天是符合要求的，判断小时是否已经过了。
                            if (now.Day < Args) {
                                now = now.AddMonths(1);
                            }

                            return new DateTime(now.Year, now.Month, now.Day, now.Hour, Minute, 0);

                    }

                    return now;
                }
            }
        }

        enum RepeatInfoUnit {
            None,
            Month,
            Week,
            Day,
            Hour
        }

    }
}
