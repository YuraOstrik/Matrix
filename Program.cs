using System.Numerics;

namespace _31._10Halloween
{
    namespace _31._10Halloween
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                ReadList mylist = new ReadList();

                Book book1 = new Book(1, "LAST");
                Book book2 = new Book(2, "The killer");
                Book book3 = new Book(3, "A-1984");

                mylist += book1;
                mylist += book2;
                mylist += book3;

                mylist.Display();

                mylist -= book1;

                mylist.Display();
                //Matrix matrix1 = new Matrix(new int[,] { { 1, 2 }, { 3, 2 } });
                //Matrix matrix2 = new Matrix(new int[,] { { 5, 5 }, { 1, 8 } });

                //Matrix sum = matrix1 + matrix2;
                //Matrix difference = matrix1 - matrix2;
                //Matrix product = matrix1 * matrix2;

                //Console.WriteLine("Matrix 1:");
                //matrix1.Display();
                //Console.WriteLine("Matrix 2:");
                //matrix2.Display();
                //Console.WriteLine("Sum:");
                //sum.Display();
                //Console.WriteLine("Difference:");
                //difference.Display();
                //Console.WriteLine("Product:");
                //product.Display();

                //Console.WriteLine($"Max in 1: {matrix1.Max()}");
                //Console.WriteLine($"Min in 1: {matrix1.Min()}");

                //Console.WriteLine($"Equal? {matrix1 == matrix2}");
            }

            public class Book
            {
                public int num { get; }
                public string name { get; set; }

                public Book(int num, string name)
                {
                    this.name = name;
                    this.num = num;
                }

                public override string ToString()
                {
                    return $" / {num} - {name}";
                }
                public override bool Equals(object? obj)
                {
                    if (obj is Book otherBook)
                    {
                        return num == otherBook.num && name == otherBook.name;
                    }
                    return false;
                }

            }

            public class ReadList
            {
                private List<Book> books = new List<Book>();

                public Book this[int index]
                {
                    get
                    {
                        if (index < 0 || index >= books.Count)
                        {
                            throw new IndexOutOfRangeException("too much ");
                        }
                        return books[index];
                    }
                    set
                    {
                        if (index < 0 || index >= books.Count)
                        {
                            throw new IndexOutOfRangeException("too much ");
                        }
                        books[index] = value;
                    }
                }

                public void Add(Book book)
                {
                    foreach (var b in books)
                    {
                        if (b.Equals(book))
                        {
                            Console.WriteLine("Эта книга уже существует в списке.");
                            return;
                        }
                    }

                    books.Add(book);
                    Console.WriteLine($"Книга '{book}' добавлена в список.");

                }

                public void Remove(Book book)
                {
                    if (books.Remove(book))
                    {
                        Console.WriteLine($"Книга '{book}' удалена из списка");
                    }
                    else
                    {
                        Console.WriteLine(" DONT Exist");
                    }
                }
                public static ReadList operator +(ReadList list, Book book)
                {
                    list.Add(book);
                    return list;
                }
                public static ReadList operator -(ReadList list, Book book)
                {
                    list.Remove(book);
                    return list;
                }
                public void Display()
                {
                    Console.WriteLine(" --- ---- ----- -");
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine(books[i]);
                    }
                }

            }


            //    public class Matrix
            //    {
            //        private int[,] data;
            //        public int Rows { get; }
            //        public int Columns { get; }

            //        public Matrix(int row, int colm)
            //        {
            //            Rows = row; Columns = colm;
            //        }

            //        public Matrix(int[,] value)
            //        {
            //            Rows = value.GetLength(0);
            //            Columns = value.GetLength(1);
            //            data = value;
            //        }

            //        public int this[int row, int col]
            //        {
            //            get
            //            {
            //                if(row < 0 || col < 0)
            //                {
            //                    throw new IndexOutOfRangeException(" Не то ");
            //                }
            //                return data[row, col];                    
            //            }
            //            set
            //            {
            //                if(row < 0 || col < 0)
            //                { throw new IndexOutOfRangeException("0-0-0-0-"); }
            //                data[row, col] = value;
            //            }
            //        }

            //        public void Display()
            //        {
            //            for(int i = 0; i < Rows; i++)
            //            {
            //                for(int j = 0; j < Columns; j++)
            //                {
            //                    Console.WriteLine(data[i, j] + "\t");
            //                }
            //                Console.WriteLine();
            //            }
            //        }

            //        public int Max()
            //        {
            //            int max = data[0, 0];
            //            for (int i = 0; i < Rows; i++)
            //            {
            //                for (int j = 0; j < Columns; j++)
            //                {
            //                    if (data[i, j] > max) ;
            //                    max = data[i, j];
            //                }

            //            }
            //            return max;
            //        }
            //        public int Min()
            //        {
            //            int min = data[0, 0];
            //            for (int i = 0; i < Rows; i++)
            //            {
            //                for (int j = 0; j < Columns; j++)
            //                {
            //                    if (data[i, j] < min) ;
            //                    min = data[i, j];
            //                }

            //            }
            //            return min;
            //        }

            //        public static Matrix operator +(Matrix a, Matrix b)
            //        {
            //            if(a.Rows != b.Rows || a.Columns != b.Columns)
            //            {
            //                throw new ArgumentException(" Mauuuu ");
            //            }
            //            Matrix result = new Matrix(a.Rows, a.Columns);
            //            for (int i = 0; i < a.Rows; i++)
            //            {
            //                for (int j = 0; j < a.Columns; j++)
            //                {
            //                    result[i,j] = a[i, j] + b[i, j];
            //                }

            //            }
            //            return result;
            //        }
            //        public static Matrix operator -(Matrix a, Matrix b)
            //        {
            //            if (a.Rows != b.Rows || a.Columns != b.Columns)
            //            {
            //                throw new ArgumentException(" Mauuuu ");
            //            }
            //            Matrix result = new Matrix(a.Rows, a.Columns);
            //            for (int i = 0; i < a.Rows; i++)
            //            {
            //                for (int j = 0; j < a.Columns; j++)
            //                {
            //                    result[i, j] = a[i, j] - b[i, j];
            //                }

            //            }
            //            return result;
            //        }
            //        public static Matrix operator *(Matrix a, Matrix b)
            //        {
            //            if (a.Rows != b.Rows || a.Columns != b.Columns)
            //            {
            //                throw new ArgumentException(" Mauuuu ");
            //            }
            //            Matrix result = new Matrix(a.Rows, a.Columns);
            //            for (int i = 0; i < a.Rows; i++)
            //            {
            //                for (int j = 0; j < a.Columns; j++)
            //                {
            //                    result[i, j] = a[i, j] * b[i, j];
            //                }

            //            }
            //            return result;
            //        }

            //        public static bool operator ==(Matrix a,Matrix b)
            //        {
            //            for(int i = 0; i < a.Rows; i++)
            //            {
            //                for(int j = 0; j < a.Columns; j++)
            //                {
            //                    if (a[i,j] != b[i, j])
            //                    {
            //                        return false;
            //                    }
            //                }
            //            }
            //            return true;
            //        }
            //        public static bool operator!=(Matrix a,Matrix b)
            //        {
            //            return !(a == b);   
            //        }
            //        public override bool Equals(object obj)
            //        {
            //            if(obj is Matrix other)
            //            {
            //                return this == other;
            //            }
            //            return false;
            //        }

            //    }
        }
    }
}
