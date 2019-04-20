﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Stump.Core.Reflection;

namespace Stump.DofusProtocol.Types
{
    public static class ProtocolTypeManager
    {
        private static readonly Dictionary<short, Type> m_types = new Dictionary<short, Type>(200);
        private static readonly Dictionary<short, Func<object>> m_typesConstructors = new Dictionary<short, Func<object>>(200);

        /// <summary>
        ///   Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(typeof (Version));

            foreach (Type type in asm.GetTypes())
            {
                FieldInfo field = type.GetField("Id");

                if (field != null)
                {
                    // le cast uint est obligatoire car l'objet n'a pas de type
                    short id = (short)field.GetValue(type);

                    m_types.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        throw new Exception(string.Format("'{0}' doesn't implemented a parameterless constructor", type));

                    m_typesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
                }
            }
        }

        /// <summary>
        ///   Gets instance of the type defined by id.
        /// </summary>
        /// <typeparam name = "T">Type.</typeparam>
        /// <param name = "id">id.</param>
        /// <returns></returns>
        public static T GetInstance<T>(short id) where T : class
        {
            if (!m_types.ContainsKey(id))
            {
                throw new ProtocolTypeNotFoundException(string.Format("Type <id:{0}> doesn't exist", id));
            }

            return m_typesConstructors[id]() as T;
        }

        [Serializable]
        public class ProtocolTypeNotFoundException : Exception
        {
            public ProtocolTypeNotFoundException()
            {
            }

            public ProtocolTypeNotFoundException(string message)
                : base(message)
            {
            }

            public ProtocolTypeNotFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }

            protected ProtocolTypeNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
}