using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp43
{
    class ErHaolei
    {
        //泛型在一开始会自动开设4个元素，后面容量自动双倍增强
        public SortedList<int, string> sortedList = new SortedList<int, string>();
        public SortedList<int, string> sortedList2 = new SortedList<int, string>();
        public string zhi;

        public void TestStack()//先进后出，后进先出（跟弹夹一个原理，栈)
        {
            Stack<int> stack = new Stack<int>(4);
            stack.Push(666);//向栈里添加元素
            stack.Push(777);
            stack.Push(888);
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine(stack.Peek()); //返回不移除
            Console.WriteLine(stack.Pop());//返回并移除
            Console.WriteLine(stack.Peek());
            foreach (var item in stack)
            {
                Console.WriteLine(stack.Pop());
            }

        }
        public void TestQueue()//先进先出，后进后出（队列）
        {
            int result = 0;
            Queue<int> queue = new Queue<int>(4);//初始化一个容量为4的队列
            queue.Enqueue(666);//向队列中添加元素
            queue.Enqueue(777);
            queue.Enqueue(888);
            // Console.WriteLine(queue.Peek());  //返回不移除
            // Console.WriteLine(queue.Dequeue());//返回并移除 
            for (int i = 0; i <= 3; i++)//TryDequeue是加了异常处理的Dequeue;
            {
                Console.WriteLine(queue.Count);
                bool ab = queue.TryDequeue(out result);
                if (ab == true)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("队列已空");
                }
            }




        }
        public void TestSortedList()
        {

            //创建一个键值都是sting的集合
            SortedList<string, string> SortedList = new SortedList<string, string>() { };
            SortedList["蜡笔小新"] = "野原新之助";
            SortedList["爸爸"] = "野原广志";
            SortedList["妈妈"] = "野原美伢";
            //初始化一些没有重复键的元素，但对应的值，有些元素是重复的。







        }
        //如果添加一个已经存在的键值对，则会抛出异常
        public void TestDate()
        {
            bool ab = false;
            int i = 0;
            do
            {
                Console.WriteLine("请输入整数的Key");
                int akay = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入元素Value");
                string Visl = Console.ReadLine();
                sortedList[akay] = Visl;

                while (true)
                {
                    if (sortedList.Count < 3)
                    {
                        Console.WriteLine("你想继续吗?继续就按1，不继续就按0");
                    }
                    else
                    {
                        Console.WriteLine("你想继续吗?继续就按1，不继续就按0，想要查询重复就按3,想根据索引查询就按4,如果想修改元素5,想创修查询就按6");
                    }


                    int shuzi = int.Parse(Console.ReadLine());
                    try
                    {
                        if (shuzi == 0)
                        {
                            ab = false;
                            break;
                        }
                        else if (shuzi == 1)
                        {
                            ab = true;
                            break;
                        }
                        else if (shuzi == 3)
                        {
                            Console.WriteLine("请在下面输入你要进行查询的键，下方将给出是否包含");
                            bool Cha = sortedList.ContainsKey(int.Parse(Console.ReadLine()));
                            if (Cha)
                            {
                                Console.WriteLine("这里面已经包含你要查询的键");
                            }
                            else
                            {
                                Console.WriteLine("这里面不包含你要查询的键");
                            }
                            Console.WriteLine("你想继续吗?继续就按1，不继续就按0");
                            int ad = int.Parse(Console.ReadLine());
                            if (ad == 1)
                            {
                                continue;
                            }
                            else if (ad == 0)
                            {
                                break;
                            }
                        }
                        else if (shuzi == 4)
                        {
                            Console.WriteLine("请输入你想查询的索引");
                            int index = int.Parse(Console.ReadLine());
                            TestIndex(index);
                            Console.WriteLine("请问你还需要继续吗?需要就按1，结束就按0。");
                            int bbc = int.Parse(Console.ReadLine());
                            if (bbc == 1)
                            {
                                break;
                            } else if (bbc == 0)
                            {
                                return;
                            }
                        }
                        else if (shuzi == 5)
                        {
                            Console.WriteLine("请输入你想查询的索引");
                            int index = int.Parse(Console.ReadLine());
                            TestIndex(index);
                            Console.WriteLine("请问你是要修改什么值。");
                            string Value = Console.ReadLine();
                            TestValue(index, Value);
                            Console.WriteLine("请问你还需要继续吗?需要就按1，结束就按0。");
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                break;
                            }
                            else if (int.Parse(Console.ReadLine()) == 0)
                            {
                                return;
                            }
                        }
                        else if (shuzi == 6)
                        {
                            TestList();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("你输入的有误，需要输入数字0或者1，并且不要输入其他任何内容。程序已结束，需要请重新发起");
                        ab = false;
                    }

                }

            } while (ab == true);




        }//用循环手动填装泛型，也可以选择查询键是否存在。并提出提示。
        //元素的键可以通过索引的方式访问。
        public void TestIndex(int index)
        {
            foreach (var item in sortedList)
            {
                if (index == sortedList.IndexOfValue(item.Value))
                {
                    Console.WriteLine(item.Value);
                }

            }




        }//通过foreach循环对泛型进行遍历，使用元素查询索引的方式判断用户输入的形参是否相等，并提供提示。
         //通过键索引，可修改其所关联的值
        public void TestValue(int index, string value)
        {
            foreach (var item in sortedList)
            {
                if (index == sortedList.IndexOfValue(item.Value))
                {
                    Console.WriteLine($"未修改时{item.Value}");
                    sortedList[item.Key] = value;
                    Console.WriteLine($"已修改后{ sortedList[item.Key]}");

                }

            }

        }

        //如果键不存在，则会新增一个键值对数据
        public void TestList()
        {
            Console.WriteLine("请输入你想查询的索引");
            bool cc = false;
            int index2 = int.Parse(Console.ReadLine());
            foreach (var item in sortedList)
            {
                if (index2 == sortedList.IndexOfKey(item.Key))
                {
                    Console.WriteLine(item.Value);
                    cc = true;
                }
              
            }
            if (cc != true)
            {
                Console.WriteLine("查无此引，故建立新的键值对,请补全值");
                sortedList2[index2] = Console.ReadLine();
                Console.WriteLine($"你输入的键是{index2},值是{ sortedList2[index2]}");

            }


        }
        //遍历循环,元素检索为KeyValuePair对象
        public void TestKeyValuePair()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(1, "a");
            keyValuePairs.Add(2, "b");
            keyValuePairs.Add(3, "c");
          
        }
        public void TestKeyValuePairAB()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.TrimExcess();
        }



    }











    
}
