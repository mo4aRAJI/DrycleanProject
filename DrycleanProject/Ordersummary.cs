using System;
using System.Collections.Generic;

namespace DrycleanProject;

public partial class Ordersummary
{
    public int? ИдентификаторЗаказа { get; set; }

    public string? ВидОдежды { get; set; }

    public string? ТипТкани { get; set; }

    public string? ЦветПредмета { get; set; }

    public string? ФиоСотрудника { get; set; }

    public short? СтажСотрудникаЛет { get; set; }

    public long? ПаспортаКлиента { get; set; }

    public string? ФиоКлиента { get; set; }

    public string? ТелефонКлиента { get; set; }

    public short? СкидкаКлиента { get; set; }

    public DateTime? ДатаПринятияЗаказа { get; set; }

    public string? СтатусЗаказа { get; set; }

    public int? СтоимостьУслугРуб { get; set; }

    public string? Название { get; set; }

    public string? Адрес { get; set; }
}
