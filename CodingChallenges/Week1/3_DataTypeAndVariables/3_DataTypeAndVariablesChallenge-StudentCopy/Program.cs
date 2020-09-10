using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
      public static void Main(string[] args)
      {
          Console.WriteLine("Hello World!");

          byte myByte = 25;
          Console.WriteLine(myByte);

          sbyte mySbyte = -15;
          Console.WriteLine(mySbyte);

          int myInt = -12318925;
          Console.WriteLine(myInt);

          uint myUint = 123091;
          Console.WriteLine(myUint);

          short myShort = -32768;
          Console.WriteLine(myShort);

          ushort myUShort = 65535;
          Console.WriteLine(myUShort);

          long myLong = -390238798320;
          Console.WriteLine(myLong);

          long myULong = 238798320332;
          Console.WriteLine(myULong);

          float myFloat = -31.1289f;
          Console.WriteLine(myFloat);

          double myDouble = -12.1231250;
          Console.WriteLine(myDouble);

          char myCharacter = 'A';
          Console.WriteLine(myCharacter);

          bool myBool = true;
          Console.WriteLine(myBool);

          string myText = "I control text";
          Console.WriteLine(myText);

          string numText = "15";
          Console.WriteLine(Text2Num(numText));

          decimal myDecimal = .004m;
          Console.WriteLine(myDecimal);


      }

      public static int Text2Num(string numText)
      {
        int num; 
        int.TryParse(numText, out num);
        return num;
      }
    }
}
