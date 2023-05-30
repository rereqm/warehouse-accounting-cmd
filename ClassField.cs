using System;
using System.IO;

public class Field
{  //fields
    private int lengthField;
    private string lineStart;
    //konstruktors
    public Field(int lengthField, string lineStart)
    {
        this.lengthField = lengthField;
        this.lineStart = lineStart;

    }
    public string completeField()
    {
        return lineStart + new string('~', (int)(lengthField - lineStart.Length));
    }
}