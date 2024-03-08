using CsvHelper.Configuration;

namespace FFFChat.Model;

/*internal class GenericMapper<T> : ClassMap<IBasic> where T : IBasic
{
    public GenericMapper()
    {
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
    }
}*/
public class MessageMapper : ClassMap<Message>
{
    public MessageMapper()
    {
        //Map(m => m.AuthorID).Name("AuthorID");
        //Map(m => m.Author).Name("Author");
        /* Map(m => m.Timestamp)
            .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
            .TypeConverterOption.Format("yyyy-MM-dd");*/
        Map(m => m.Date)
            .Name("Date")
            .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
            .TypeConverterOption.Format("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
        //Map(m => m.Date).Name("Date");
        Map(m => m.Content).Name("Content");
        //Map(m => m.Attachments).Name("Attachments");
        //Map(m => m.Reactions).Name("Reactions");
    }
}