﻿using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Media;
using Newtonsoft.Json;
using WinHue3.Philips_Hue.Communication;
using WinHue3.Philips_Hue.HueObjects.Common;
using WinHue3.Utils;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace WinHue3.Philips_Hue.HueObjects.ScheduleObject
{
    /// <summary>
    /// Class for a schedule.
    /// </summary>
    [DataContract, HueType("schedules"), JsonConverter(typeof(ScheduleJsonConverter))]
    public class Schedule : ValidatableBindableBase, IHueObject
    {
        private string _name;
        private ImageSource _image;
        private string _id;
        private string _localtime;
        private string _description;
        private Command _command;
        private string _status;
        private bool? _recycle;
        private string _created;
        private bool? _autodelete;
        private string _starttime;
        private bool _visible;

        /// <summary>
        /// Image of the rule.
        /// </summary>
        [DataMember, Category("Schedule Properties"), Description("Image of the Schedule"), ReadOnly(true), Browsable(false), JsonIgnore]
        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image,value);
        }

        /// <summary>
        /// ID of the rule.
        /// </summary>
        [DataMember, Category("Schedule Properties"), Description("ID of the Schedule"), ReadOnly(true),Browsable(false), JsonIgnore]
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id,value);
        }

        /// <summary>
        /// Name of the Schedule.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Name of the schedule")]
        public string name
        {
            get => _name;
            set => SetProperty(ref _name,value);
        }

        /// <summary>
        /// Time when the scheduled event will occur in ISO 8601:2004 format.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Local Time of the schedule")]
        public string localtime
        {
            get => _localtime;
            set => SetProperty(ref _localtime,value);
        }

        /// <summary>
        /// Description of the schedule
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Description of the schedule")]
        public string description
        {
            get => _description;
            set => SetProperty(ref _description,value);
        }

        /// <summary>
        /// Command to be executed when the schedule is triggered
        /// </summary>
        [HueProperty, DataMember, ExpandableObject, Category("Command"), Description("Command of the schedule")]
        public Command command
        {
            get => _command;
            set => SetProperty(ref _command,value);
        }

        /// <summary>
        /// Status of the schedule.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Command of the schedule"), ItemsSource(typeof(StatusItemsSource))]
        public string status
        {
            get => _status;
            set => SetProperty(ref _status,value);
        }

        /// <summary>
        /// Recycle the schedule.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Command of the schedule"), CreateOnly]
        public bool? recycle
        {
            get => _recycle;
            set => SetProperty(ref _recycle,value);
        }

        /// <summary>
        /// Start time of the timer.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Start time of the timer (if one)"), ReadOnly(true)]
        public string starttime
        {
            get => _starttime;
            set => SetProperty(ref _starttime, value);
        }

        /// <summary>
        /// Date created.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Command of the schedule"),ReadOnly(true)]
        public string created
        {
            get => _created;
            set => SetProperty(ref _created,value);
        }

        /// <summary>
        /// Autodelete.
        /// </summary>
        [HueProperty, DataMember, Category("Schedule Properties"), Description("Autodelete the schedule")]
        public bool? autodelete
        {
            get => _autodelete;
            set => SetProperty(ref _autodelete,value);
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false), ReadOnly(true), JsonIgnore, Browsable(false)]
        public bool visible
        {
            get { return _visible; }
            set { SetProperty(ref _visible,value); }
        }

        /// <summary>
        /// To String.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Serializer.SerializeToJson(this);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
