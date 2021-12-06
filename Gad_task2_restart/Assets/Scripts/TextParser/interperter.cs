using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interperter : MonoBehaviour
{
    
    
        public delegate bool ExecuteCommand(List<Token> objects);
        Dictionary<string, ExecuteCommand> commandMethods;
        public interperter()
        {
            commandMethods = new Dictionary<string, ExecuteCommand>();
        }

        public void AddCommandMethods(string word, ExecuteCommand commandMethod)
        {
            if (!commandMethods.ContainsKey(word))
            {
                commandMethods.Add(word, commandMethod);
            }
        }

        public bool Interpert(List<Token> tokens)
        {
            bool haserror = false;

            if (tokens[0].TokenType == TokenType.COMMAND)
            {
                ExecuteCommand execute;
                if (commandMethods.TryGetValue(tokens[0].LiteralValue, out execute))
                {
                    if (!execute(tokens))
                    {
                        haserror = true;
                    }
                }
            }
            else
            {
                haserror = true;
            }

            return haserror;
        }
    

   
}
