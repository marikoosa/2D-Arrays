using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace assignN1
{
    //IComparable provides a method (CompareTo()) of comparing two objects
    class MobileObject : IComparable
    {
        // Variable declaration
        public string Name;
        public int Id;
        public Position Pos;
        public int PositionCell;

        //Constructor for the base class
        public MobileObject(string Name, int Id, Position Pos)
        {
            this.Name = Name;
            this.Id = Id;
            this.Pos = Pos;
        }

        // Get and Set accessors for MobileObject variables.
        public void SetName(string desiredname)
        {
            Name = desiredname;
        }

        public string GetName()

        {
            return Name;
        }

        public void SetId(int desiredid)

        {
            Id = desiredid;
        }

        public int GetId()

        {
            return Id;
        }

        /* Declaring a virtual Print method to Allow
           Cat and Snake sub classes to override it*/

        public virtual string Print()

        {
            return Name + " " + Id;
        }

        /* Move method changes object position
        and calculates a new position*/
        public void Move(float dx, float dy, float dz)

        {
            Pos.SetX(dx + Pos.GetX());
            Pos.SetY(dy + Pos.GetY());
            Pos.SetZ(dz + Pos.GetZ());
        }

        //Get and Set accessors for PositionCell
        public void SetPositionCell(int DesiredPositionCell)

        {
            this.PositionCell = DesiredPositionCell;
        }

        public int GetPositionCell()

        {
            return PositionCell;
        }

        /* IComparable enables CompareTo method to
        compare objects (of type MobileObject) with their Z value */
        public int CompareTo(object obj)
        {
            if (obj is MobileObject)
            {
                return Convert.ToInt32(this.Pos.GetZ() <= (obj as MobileObject).Pos.GetZ());
            }
            throw new ArgumentException("Object is not a MobileObject");
        }
    }

    /*****************************************************************************/

    //Cat class Inherits from MobileObject class. 
    class Cat : MobileObject
    {
        // Variable declaration.
        public float LegLength;
        public float TorsoLength;
        public float HeadLength;
        public float TailLength;
        public float Mass;

        /*Constructor for Cat class
        (name, Id, and pos variables are inherited from MobileObject class)*/
        public Cat(string name, int Id, Position pos, float legLength,
            float torsoLength, float HeadLength, float tailLength, float mass)
                : base(name, Id, pos)
        {
            this.LegLength = legLength;
            this.TorsoLength = torsoLength;
            this.HeadLength = HeadLength;
            this.TailLength = tailLength;
            this.Mass = mass;
        }

        //Get and Set accessors for Cat class variables. 
        public float GetLegLength()
        {
            return LegLength;
        }
        //Setting Leg Length variable to be greater than zero.
        public void SetLegLength(float value)
        {
            if (value > 0) LegLength = value;
        }

        public float GetTorsoLength()
        {
            return TorsoLength;
        }

        //Setting Torso Length variable to be greater than zero.
        public void SetTorsoLength(float value)
        {
            if (value > 0) TorsoLength = value;
        }

        public float GetHeadLength()
        {
            return HeadLength;
        }
        //Setting Head Length variable to be greater than zero.
        public void SetHeadLength(float value)
        {
            if (value > 0) HeadLength = value;
        }

        public float GetTailLength()
        {
            return TailLength;
        }

        //Setting Tail Length variable to be greater than zero.
        public void SetTailLength(float value)
        {
            if (value > 0) TailLength = value;
        }

        public float GetMass()
        {
            return Mass;
        }
        //Setting Mass variable to be greater than zero.
        public void SetMass(float value)
        {
            if (value > 0) Mass = value;
        }


        //TotalLength() method calculates total length of a Cat.
        private float TotalLength()
        {
            return LegLength + TorsoLength + HeadLength;
        }

        //Print method that overrrides virtual string Print() in the base class. 
        public override string Print()
        {
            return "Name: " + Name + " ID: " + Id + " Positions: " + Pos.GetX() + " "
                   + Pos.GetY() + " " + Pos.GetZ() + " Leg length: " + LegLength +
                   " Torso Height: " + TorsoLength + " Head Height: " + HeadLength +
                   " Tail Length " + TailLength + " Mass " + Mass + " Total Height: " + TotalLength();
        }
    }

    /*****************************************************************************/

    //Snake class Inherites from MobileObject
    class Snake : MobileObject
    {
        // Variable declaration.
        float Length;
        float Radius;
        float Mass;
        int Vertebrae;

        /*Constructor for the Snake class
        (name, Id, and pos variables are inherited from MobileObject class)*/
        public Snake(string name, int Id, Position pos, float length,
            float radius, float mass, int vertebrae)
                : base(name, Id, pos)
        {
            this.Length = length;
            this.Radius = radius;
            this.Mass = mass;
            this.Vertebrae = vertebrae;
        }

        //Get and Set accessors for Snake class variables. 
        public float GetLength()
        {
            return Length;
        }
        //Setting Length variable to be greater than zero.
        public void SetLength(float value)
        {
            if (value > 0) Length = value;
        }

        public float GetRadius()
        {
            return Radius;
        }
        //Setting Radius variable to be greater than zero.
        public void SetRadius(float value)
        {
            if (value > 0) Radius = value;
        }

        public int GetVertebrae()
        {
            return Vertebrae;
        }
        //Setting Vertebrae variable to be greater than zero.
        public void SetVertebrae(int value)

        {
            if (value >= 200 && value <= 300) Vertebrae = value;
        }

        public float GetMass()
        {
            return Mass;
        }
        //Setting Mass variable to be greater than zero.
        public void SetMass(float value)
        {
            if (value > 0) Mass = value;
        }

        //BoundingVolume() Calculates the Volume
        private float BoundingVolume()
        {
            return (float)(Length * Math.Pow(Radius, 2) * Math.PI);
        }

        //Print method that overrrides virtual string Print() in the base class. 
        public override string Print()
        {
            return "Name: " + Name
                   + " ID: " + Id + " Positions: " + Pos.GetX() + " " + Pos.GetY() + " " + Pos.GetZ()
                   + " Length: " + Length + " Height: " + Radius + " Width: " + Vertebrae
                   + " Volume: " + BoundingVolume();
        }

    }

    /*****************************************************************************/

    class Position
    {
        //Variable declaration for Position class.
        public float x, y, z;

        //Constructor for Position class that takes 3 arguments
        public Position(float x, float y, float z)

        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Constructor for position class that only takes one argument. 
        public Position(int maxsize)
        {
            Random random = new Random();
            this.x = random.Next(0, maxsize);
            this.y = random.Next(0, maxsize);
            this.z = 0;
        }

        // Gettters and Setters for Position class.
        public void SetX(float valX)
        {
            this.x = valX;
        }

        public float GetX()
        {
            return this.x;
        }

        public void SetY(float valY)
        {
            this.y = valY;
        }

        public float GetY()
        {
            return this.y;
        }

        public void SetZ(float valZ)
        {
            this.z = valZ;
        }

        public float GetZ()
        {
            return this.z;
        }
    }

    /****************************************************************************************************/

    class Cell

    {   //Declaring variables for Cell class 
        public int CellId;
        public float Dimension = 10.0F;
        public int[] Position = new int[2]; //Initializing Position array with 2 elements (x,y) 
        public ArrayList objs = new ArrayList();

        //A constructor for the Cell class 
        public Cell(int Id, int x, int y)
        {
            this.CellId = Id;
            this.Position[0] = x;
            this.Position[1] = y;
        }

        // Get and Set accessors for CellId variable 
        public void SetCellId(int IdVal)
        {
            this.CellId = IdVal;
        }

        public int GetCellId()
        {
            return this.CellId;
        }

        //Get accessor for position array
        public int[] GetCellPosition()
        {
            return Position;
        }

        // addObj method adds an object to a cell. Is used by Move() method
        private void addObj(MobileObject obj)
        {

            objs.Add(obj);
            objs.Sort();
        }

        //// removeObj method removes an object from a cell. Is used by Move() method
        private void removeObj(MobileObject obj)
        {

            objs.Remove(obj); 
        }

        /*****************************************************************************/

        class Grid

        {
            // Variable declaration for the Grid class
            public const int size = 16; //The grid will be Size by Size (ex 10x10)
            public const int cell_size = 10;
            public const int BAD_ID = -1;
            public Cell[,] cells = new Cell[size, size]; // creating 2D array of cells 

            //constructor creates Grid by calling CreateGrid() method 
            public Grid()
            {
                CreateGrid();
            }

            //GenerateID() method generates and returns cell id
            public int GenerateID(int x, int y)
            {
                return (x + y * size + 1000);
            }

            //CreateGrid() method creates grid using the 2 Dimensional array of cells.
            public void CreateGrid()
            {   
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {

                        int Id = GenerateID(i, j);
                        int x = i * cell_size;
                        int y = j * cell_size;
                        cells[i, j] = new Cell(Id, x, y);
                    }
                }
            }

            //Finds maximum value so cells stay within the grid
            public int GetMaxVal()
            {
                return (size * cell_size - 1);
            }

            public int GetCellID(Position position) // calling GetCellID method and passing position to it. 

            {   // Negative numbers are not useful.
                if (position.x < 0 || position.y < 0)
                {
                    return BAD_ID;
                }

                int max_val = GetMaxVal(); 

                // Numbers greater than max_val are not useful.
                if (position.x > max_val || position.y > max_val)
                {
                    return BAD_ID;
                }
                int x = (int)position.x / cell_size;
                int y = (int)position.y / cell_size;

                return GenerateID(x, y);
            }

            //Method that prints the grid.
            public void Print(LinkedList<MobileObject> mobile)
            {
                Console.WriteLine("Grid:");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (cells[j, i].objs.Count > 0)
                        {

                            //Printing the cells that hold mobile objects. 
                            Console.Write(String.Format("[{0,2}]\t", (cells[j, i].objs[0] as MobileObject).GetId()));
                        }
                        else
                        {   //if the cell does not contain an object it print an empty cell [ ], no id"
                            Console.Write("[  ]\t");

                        }

                    }
                    // Printing values 10 to 160 across X and Y "axis" 
                    Console.WriteLine(cell_size * (i + 1));
                }

                for (int j = 0; j < size; j++)
                {
                    Console.Write((j + 1) * cell_size + "\t");
                }
                Console.WriteLine("");

                //Printing which object is in which cell on the grid
                foreach (MobileObject mob in mobile)
                {
                    Console.WriteLine(mob.GetName() + " is in cell with id: " + mob.GetPositionCell());
                }
            }
        }

        /**********************************************************/

        class Program
        {
            static void Main(string[] args)

            {   // Reading in cat and snake name files 
                string[] catnames = File.ReadAllLines(@"Assignment 1 catnames.txt");
                string[] snakenames = File.ReadAllLines(@"Assignment 1 snakenames.txt");

                Random random = new Random(); //Creating "random" algorith to hold randomly generated values 
                Grid grid = new Grid(); // creating a Grid by calling Grid() consructor 


                //Creates a linked list of moblie objects.
                LinkedList<MobileObject> mobile = new LinkedList<MobileObject>();
                MobileObject[] mobilearray = new MobileObject[10]; //Indicating the number of mobile object to be generated

                //Using regular expression to eliminate the numbering of the cat names from the file that we read in. 
                Regex regex = new Regex(@"\d*\.\s*(\w*)");
                Match match;
                
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {

                        if (i == 0)
                        {
                            match = regex.Match(catnames[random.Next(0, catnames.Length)]);
                            string randomcatname = match.Groups[1].Value;

                            /*adding mobile objects to a linked list and 
                            determinig the the value range of cat attributes*/
                            mobile.AddLast(new Cat(randomcatname,
                                                   mobile.Count(),
                                                   new Position(grid.GetMaxVal()),
                                                   /*To make Cat attribute values a float I used (float)
                                                     keyword, devided the values by 2 and added a floating point number.*/
                                                   (float)((random.NextDouble() / 2) + 0.5), //Leglength
                                                   (float)((random.NextDouble() / 2) + 0.5), //Torsoheight
                                                   (float)((random.NextDouble() / 2) + 0.5),//HeadLength
                                                   (float)((random.NextDouble() / 2) + 0.5),//Taillength
                                                   (float)((random.NextDouble() / 2) + 0.5)));//Mass
                            mobile.Last().SetPositionCell(grid.GetCellID(mobile.Last().Pos));
                        }

                        else

                        {   /*adding mobile objects to a linked list and 
                            determinig the the value range of snake attributes*/
                            mobile.AddLast(new Snake(snakenames[random.Next(0, snakenames.Length)],
                                                     mobile.Count(),
                                                     new Position(grid.GetMaxVal()),
                                                     /*To make length and radius values a float I used (float)
                                                     keyword, devided the values by 2 and added a floating point number.*/
                                                     (float)((random.NextDouble() / 2) + 0.5), //Length
                                                     (float)((random.NextDouble() / 10) + 0.05), //Radius
                                                     (float)((random.NextDouble() * 100) + 1),//Mass in kg
                                                     random.Next(200, 301)));//Vertabrae
                            mobile.Last().SetPositionCell(grid.GetCellID(mobile.Last().Pos));
                        }
                        Move(mobile.Last(), 0, 0, 0, true);
                        int index = (i * 5) + j;
                    }
                }
                // Turning a list into an array
                mobilearray = mobile.ToArray();

                //initializing newmobilearray with the space for 10 elements in it. 
                MobileObject[] newmobilearray = new MobileObject[10];

                int n = mobilearray.Length;

                //The for loop places items in newmobilearray[] in random locations
                for (int i = 0; i < n; i++)
                {
                    int j = random.Next(0, n);
                    MobileObject t = mobilearray[i];

                    if (newmobilearray[j] == null)
                    {
                        newmobilearray[j] = t;
                    }
                    else
                    {
                        i--;
                    }
                }

                //The method lets users create a new object.
                void CreateObject()

                {   //The user can choose which type of object they want to create. 
                    Console.Write("Choose the type of object you want to create \n1. Create a Cat \n2. Create a Snake\nChoice: ");

                    string objType = Console.ReadLine(); //Storing the user input in objType variable

                    //If the user makes an incorrect choice they are prompted to try again 
                    if (objType != "1" && objType != "2") 
                    {
                        Console.WriteLine("Invalid Input, Please try again.");
                        return;
                    }
                    else
                    {   /*If the user makes a correct choice for the first question they are asked 
                        to enter the attributes that cats and snakes share*/

                        Console.Write("Enter name. \nChoice: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter position.");
                        Console.Write("Pos x: ");
                        string posx = Console.ReadLine();
                        Console.Write("Pos y: ");
                        string posy = Console.ReadLine();
                        Console.Write("Pos z: ");
                        string posz = Console.ReadLine();

                        /*If the user has selected the cat in the first question 
                        they are asked to enter the cat attributes attributes*/

                        if (objType == "1")
                        {

                            Console.Write("Enter leg length. \nChoice: ");
                            string leg = Console.ReadLine(); //Storing user input in the leg variable

                            Console.Write("Enter torso length \nChoice: ");
                            string torso = Console.ReadLine();//Storing user input in the torso variable

                            Console.Write("Enter head size. \nChoice: ");
                            string head = Console.ReadLine(); //Storing user input in the head variable 

                            Console.Write("Enter tail length. \nChoice: ");
                            string tail = Console.ReadLine(); //Storing user input in thetail variable 

                            Console.Write("Enter mass. \nChoice: ");
                            string mass = Console.ReadLine(); //Storing user input in the mass variable 

                            try
                            {
                                //Ensuring that object creation fails if the user enters a negative value for the properties
                                if (float.Parse(leg) <= 0 || float.Parse(torso) <= 0 || float.Parse(head) <= 0 || float.Parse(tail) <= 0 || float.Parse(mass) <= 0)
                                {
                                    Console.WriteLine("Can't have negative value for properties.");
                                    return;
                                }
                                //Adding the new cat object to the list 
                                mobile.AddLast(new Cat(name,
                                                       mobile.Count(),
                                                       new Position(float.Parse(posx), float.Parse(posy), float.Parse(posz)),
                                                       float.Parse(leg),
                                                       float.Parse(torso),
                                                       float.Parse(head),
                                                       float.Parse(tail),
                                                       float.Parse(mass)));
                            }
                            catch
                            {   //Prints if the object creation fails due to the user entering invalid input 
                                Console.WriteLine("Invalid selection on one of the traits.");
                            }
                        }
                        /*If the user has selected to create a snake in the first question 
                       they are asked to enter the snake attributes*/
                        else if (objType == "2")
                        {
                            Console.Write("Enter length. \nChoice: ");
                            string length = Console.ReadLine(); //Storing user input in the length variable 

                            Console.Write("Enter radius \nChoice: ");
                            string radius = Console.ReadLine();//Storing user input in the radius variable

                            Console.Write("Enter mass. \nChoice: ");
                            string mass = Console.ReadLine(); //Storing user input in the mass variable

                            Console.Write("Enter vertebrae. \nChoice: ");
                            string vertebrae = Console.ReadLine(); //Storing user input in vertebrae variable 

                            try
                            {   //Ensuring that object creation fails if the user enters a negative value 
                                if (float.Parse(length) <= 0 || float.Parse(radius) <= 0 || float.Parse(mass) <= 0 || float.Parse(vertebrae) <= 0)
                                {
                                    Console.WriteLine("Objects can not have negative value for properties.");
                                    return;
                                }
                                //Adding the new Snake object to the list 
                                mobile.AddLast(new Snake(name,
                                                         mobile.Count(),
                                                         new Position(float.Parse(posx), float.Parse(posy), float.Parse(posz)),
                                                         float.Parse(length),
                                                         float.Parse(radius),
                                                         float.Parse(mass),
                                                         int.Parse(vertebrae)));

                            }
                            catch
                            {   //Prints if the object creation fails due to the user entering invalid input
                                Console.WriteLine("Invalid selection on one of the traits.");

                            }
                        }
                        // Update grid with the new object
                        mobile.Last().SetPositionCell(grid.GetCellID(mobile.Last().Pos));
                        Move(mobile.Last(), 0, 0, 0, true);
                    }
                }

                /* Move() method is called by MoveObject(). MoveObject() asks the user
                which object they want to move and to which cell. Move() moves the object.*/

                void Move(MobileObject obj, float dx, float dy, float dz, bool flag = false)
                {
                    int currentcellid = obj.GetPositionCell();
                    obj.Move(dx, dy, dz);
                    int newcellid = grid.GetCellID(obj.Pos); 

                    if (currentcellid != newcellid || flag || dz != 0)
                    {
                        int size = Grid.size;
                        obj.SetPositionCell(newcellid);
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (grid.cells[j, i].GetCellId() == currentcellid && grid.cells[j, i].objs.Contains(obj))
                                {
                                    grid.cells[j, i].removeObj(obj);
                                }

                                if (grid.cells[j, i].GetCellId() == newcellid)
                                {
                                    grid.cells[j, i].addObj(obj);
                                }
                            }
                        }
                    }
                }

                /* MoveObject() asks the user which position they want to move
                 the object from and where to place them. */

                void MoveObject()

                {   //making sure that we catch whe the user enters invalid id 
                    Console.Write("Enter object Id: ");
                    int Id = -1;
                    try
                    {
                        Id = Int32.Parse(Console.ReadLine()); //if the id = -1 = user input 
                    }
                    catch
                    {
                        Console.WriteLine("Id must be an integer."); //we let the user know that it is an invalid id 
                        return;
                    }
                    foreach (MobileObject obj in mobile) 
                    {
                        if (obj.GetId() == Id)
                        {
                            float dx, dy, dz;
                            try
                            {
                                Console.Write("Input dx: ");
                                dx = float.Parse(Console.ReadLine()); // Reading in the user input for dx
                                Console.Write("Input dy: ");
                                dy = float.Parse(Console.ReadLine());// Reading in the user input for dy
                                Console.Write("Input dz: ");
                                dz = float.Parse(Console.ReadLine()); // Reading in the user input for dz
                            }
                            catch
                            {
                                Console.WriteLine("Invalid entry, values must be floats.");
                                return;
                            }
                            Move(obj, dx, dy, dz); //passing the 

                        }
                    }
                }

                void printObjects()
                {
                    foreach (MobileObject mob in mobile)
                    {
                        Console.WriteLine(mob.Print());
                    }
                }
                /******************************************************************************************************************/
                void MoveAndUpdate()
                {
                    foreach (MobileObject mob in mobile)
                    {
                        Move(mob, (float)((random.NextDouble() * 10) + 0.1), (float)((random.NextDouble() * 10) + 0.1), (float)((random.NextDouble() * 2) + 0.1));
                    }
                }
                void MoveOrigin()
                {
                    Console.WriteLine("Change Origin.");
                    float dx, dy, dz;
                    try
                    {
                        Console.Write("Input dx: ");
                        dx = float.Parse(Console.ReadLine());
                        Console.Write("Input dy: ");
                        dy = float.Parse(Console.ReadLine());
                        Console.Write("Input dz: ");
                        dz = float.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry, values must be floats.");
                        return;
                    }

                    foreach (MobileObject mob in mobile)
                    {
                        Move(mob, -dx, -dy, -dz);
                    }
                }
                void FindWithinDistance()
                {
                    float distance;
                    try
                    {
                        Console.Write("Input distance: ");
                        distance = float.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry, values must be floats.");
                        return;
                    }

                    foreach (MobileObject mob in mobile)
                    {
                        float mobdist = (float)Math.Sqrt(Math.Pow(mob.Pos.GetX(), 2) + Math.Pow(mob.Pos.GetY(), 2) + Math.Pow(mob.Pos.GetZ(), 2));
                        if (mobdist <= distance)
                        {
                            Console.WriteLine(mob.Print());
                        }
                    }
                }

                /*********************************************************************************************************************************/

                bool continueflag = true;
                while (continueflag)
                {
                    Console.Write("Menu\n1. Create Object\n2. Move Object\n3. Print Grid\n4. Print all objects\n5. Move and Update\n6. Move Origin\n7. Find Within Distance\nQ. Quit\nInput: ");
                    string userinput = Console.ReadLine();
                    switch (userinput)
                    {
                        case "1":
                            CreateObject();
                            break;

                        case "2":
                            MoveObject();
                            break;

                        case "3":
                            grid.Print(mobile);
                            break;

                        case "4":
                            printObjects();
                            break;

                        case "5":
                            MoveAndUpdate();
                            break;

                        case "6":
                            MoveOrigin();
                            break;

                        case "7":
                            FindWithinDistance();
                            break;

                        case "Q":
                            continueflag = false;
                            break;

                        default:
                            Console.WriteLine("Unknown input");
                            break;

                    }
                }
            }
        }
    }
}
