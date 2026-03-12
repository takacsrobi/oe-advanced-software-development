//Módosítsd a Storage osztály delegáltjait beépített delegáltakra
//A külső függvényeket Lambda kifejezéssel add át!

using CustomStorage;

//void WriteOut(string item)
//{
//    Console.WriteLine(item);
//}

//string Upper(string item)
//{
//    return item.ToUpper();
//}

//string Format(string item)
//{
//    return "--- " + item + " ---";
//}


Storage<string> st = new Storage<string>(5);
st.AddTransformer(t => t.ToUpper());
st.AddTransformer(t => "--- " + t + " ---");

st.Add("Jack");
st.Add("Kate");
st.Add("John");
st.Add("Michael");

st.Traverse(Console.WriteLine);