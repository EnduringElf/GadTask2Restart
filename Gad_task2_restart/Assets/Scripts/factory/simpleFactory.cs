using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

namespace ReflectionFactory
{
    public static class simpleFactory
    {
        private static Dictionary<string,Type> NPCbytype;
        private static bool IsInstatiated => NPCbytype != null;

        public static void InitilizedFactory()
        {
            if (IsInstatiated) return;
            var NPCtypes = Assembly.GetAssembly(typeof(Spawner)).GetTypes().Where(mytype => mytype.IsClass && !mytype.IsAbstract && mytype.IsSubclassOf(typeof(Spawner)));

            NPCbytype = new Dictionary<string, Type>();

            foreach(var type in NPCtypes)
            {
                var tempspanwer = Activator.CreateInstance(type) as Spawner;
                NPCbytype.Add(tempspanwer.name, type);
            }
        }


        public static Spawner getSpawner(string spawnertype)
        {
            if (NPCbytype.ContainsKey(spawnertype))
            {
                Type type = NPCbytype[spawnertype];
                var spawner = Activator.CreateInstance(type) as Spawner;
                return spawner;
            }
            return null;
        }

        internal static IEnumerable<string> GetSpawneNames()
        {
            return NPCbytype.Keys;
        }
    }

   

    public abstract class Spawner
    {
        public abstract string name { get; }
        public abstract void Process();


    }

    public class Spawnerrandom : Spawner
    {
        public override string name => "Random NPC";
        public override void Process()
        {
            //spawn fluff npc
        }

    }

    

}



