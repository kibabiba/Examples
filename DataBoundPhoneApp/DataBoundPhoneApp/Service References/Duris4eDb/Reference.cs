//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18033
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 17.03.2013 21:58:25
namespace DataBoundPhoneApp.Duris4eDb
{
    
    /// <summary>
    /// There are no comments for Duris4eEntities in the schema.
    /// </summary>
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    public partial class Duris4eEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new Duris4eEntities object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Duris4eEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("Duris4eModel", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("DataBoundPhoneApp.Duris4eDb", typeName.Substring(12)), false);
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("DataBoundPhoneApp.Duris4eDb", global::System.StringComparison.Ordinal))
            {
                return string.Concat("Duris4eModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for holidays in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<holidays> holidays
        {
            get
            {
                if ((this._holidays == null))
                {
                    this._holidays = base.CreateQuery<holidays>("holidays");
                }
                return this._holidays;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<holidays> _holidays;
        /// <summary>
        /// There are no comments for holidays in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToholidays(holidays holidays)
        {
            base.AddObject("holidays", holidays);
        }
    }
    /// <summary>
    /// There are no comments for Duris4eModel.holidays in the schema.
    /// </summary>
    /// <KeyProperties>
    /// day_time
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("holidays")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("day_time")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    public partial class holidays : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new holidays object.
        /// </summary>
        /// <param name="day_time">Initial value of day_time.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static holidays Createholidays(global::System.DateTime day_time)
        {
            holidays holidays = new holidays();
            holidays.day_time = day_time;
            return holidays;
        }
        /// <summary>
        /// There are no comments for Property day_time in the schema.
        /// </summary>
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime day_time
        {
            get
            {
                return this._day_time;
            }
            set
            {
                this.Onday_timeChanging(value);
                this._day_time = value;
                this.Onday_timeChanged();
                this.OnPropertyChanged("day_time");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _day_time;
        partial void Onday_timeChanging(global::System.DateTime value);
        partial void Onday_timeChanged();
        /// <summary>
        /// There are no comments for Property desc in the schema.
        /// </summary>
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this.OndescChanging(value);
                this._desc = value;
                this.OndescChanged();
                this.OnPropertyChanged("desc");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _desc;
        partial void OndescChanging(string value);
        partial void OndescChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}