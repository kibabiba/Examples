//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.296
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// Исходное имя файла:
// Дата создания: 20.03.2013 12:44:13
namespace ConsoleApplication1.TestDataService
{
    
    /// <summary>
    /// В схеме отсутствуют комментарии для Duris4eEntities.
    /// </summary>
    public partial class Duris4eEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Инициализируйте новый объект Duris4eEntities.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Duris4eEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Поскольку пространство имен, настроенное для этой ссылки на службу
        /// в Visual Studio, отличается от пространства имен, указанного
        /// в схеме сервера, для сопоставления этих пространств имен используйте преобразователи типов.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("Duris4eModel", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("ConsoleApplication1.TestDataService", typeName.Substring(12)), false);
            }
            return null;
        }
        /// <summary>
        /// Поскольку пространство имен, настроенное для этой ссылки на службу
        /// в Visual Studio, отличается от пространства имен, указанного
        /// в схеме сервера, для сопоставления этих пространств имен используйте преобразователи типов.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("ConsoleApplication1.TestDataService", global::System.StringComparison.Ordinal))
            {
                return string.Concat("Duris4eModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// В схеме отсутствуют комментарии для holidays.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<holidays> _holidays;
        /// <summary>
        /// В схеме отсутствуют комментарии для holidays.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToholidays(holidays holidays)
        {
            base.AddObject("holidays", holidays);
        }
    }
    /// <summary>
    /// В схеме отсутствуют комментарии для Duris4eModel.holidays.
    /// </summary>
    /// <KeyProperties>
    /// day_time
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("holidays")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("day_time")]
    public partial class holidays : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Создайте новый объект holidays.
        /// </summary>
        /// <param name="day_time">Начальное значение day_time.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static holidays Createholidays(global::System.DateTime day_time)
        {
            holidays holidays = new holidays();
            holidays.day_time = day_time;
            return holidays;
        }
        /// <summary>
        /// В схеме отсутствуют комментарии для свойства day_time.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _day_time;
        partial void Onday_timeChanging(global::System.DateTime value);
        partial void Onday_timeChanged();
        /// <summary>
        /// В схеме отсутствуют комментарии для свойства desc.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _desc;
        partial void OndescChanging(string value);
        partial void OndescChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}