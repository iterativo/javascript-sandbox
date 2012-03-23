using System.ComponentModel.DataAnnotations;

namespace scratch.Misc.MetadataTypeStuff
{
    [MetadataType(typeof(FooMetaClass))]
    public class Foo
    {
        public string Baz;
        public string Bar { get; set; }
        public string UncoolField;
        public string UncoolProp { get; set; }
    }

    public class FooMetaClass
    {
        [IsCool]
        public string Baz;

        [IsCool]
        public string Bar { get; set; }
    }
}