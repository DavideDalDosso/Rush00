using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Prop
{
    private string name = "";
    private string description = "";

    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return name;
    }
    public void SetDescription(string desc)
    {
        description = desc;
    }
    public string GetDescription()
    {
        return description;
    }
}
