using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AdventureEngine
{
    private List<Room> rooms = new List<Room>();
    private Room currentRoom;
    private int propsPerLine = 1;
    private string prevActionMessage = "";

    public void InputPrompt()
    {
        Console.WriteLine("1 = LOOK OBJECT; 2 = GO EXIT");
        int option = Util.ReadNumber<int>( () => Console.WriteLine("Please put a valid option") );
        switch( option)
        {
            case 1:
                PropLookPrompt();
                break;
            case 2:
                GoExitPrompt();
                break;
        }
    }

    public void OutputRoomDesc()
    {
        Console.WriteLine("----- " + currentRoom.GetName() + " -----\n");

        if(prevActionMessage != "")
        {
            Console.WriteLine("\n"+prevActionMessage+"\n");
            prevActionMessage = "";
        }

        Console.WriteLine(currentRoom.GetDescription()+"\n\n");
        OutputRoomProps();
        Console.WriteLine("\n");
        var exits = currentRoom.GetExits();
        for (int i=0; i<exits.Count(); i++)
        {
            Console.WriteLine((i+1) + " - " + exits[i].GetName());
        }
        Console.WriteLine("-------------------------(@)");
    }
    public void GoExitPrompt()
    {
        Console.WriteLine("WHICH EXIT?");
        int exitOption = Util.ReadNumber<int>(() => Console.WriteLine("Please put a valid option"));
        var exit = currentRoom.GetExit( exitOption-1 );
        if(exit == null)
        {
            Console.Clear();
            OutputRoomDesc();
            Console.WriteLine("Index not available");
            GoExitPrompt();
            return;
        }
        ChangeRoom(exit);
    }
    public void PropLookPrompt()
    {
        Console.WriteLine("WHICH OBJECT?");
        int propOption = Util.ReadNumber<int>(() => Console.WriteLine("Please put a valid option"));
        var prop = currentRoom.GetProp(propOption - 1);
        if (prop == null)
        {
            Console.Clear();
            OutputRoomDesc();
            Console.WriteLine("Index not available");
            PropLookPrompt();
            return;
        }
        prevActionMessage = prop.GetName() + " - " + prop.GetDescription();
    }
    public void OutputRoomProps()
    {
        var buffer = "The room contains:\n";
        var props = currentRoom.GetProps();
        for (int i = 0; i < props.Count(); i++)
        {
            buffer += (i+1) + " - " + props[i].GetName();
            if (i < props.Count() - 1) buffer += ", ";
            if(i % propsPerLine == propsPerLine - 1) buffer += "\n";
        }
        Console.WriteLine(buffer);
    }
    public void ChangeRoom(Room exit)
    {
        currentRoom = exit;
    }
    public void Start(Room room)
    {
        currentRoom = room;

        do
        {
            Console.Clear();
            OutputRoomDesc();
            InputPrompt();
        } while (true);
    }

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }
    public void SetPropsPerLine(int n)
    {
        propsPerLine = n;
    }
}
