using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.search.Module
{
    public class ElasticSearchEntity : DynamicObject
    {
        private Dictionary<string, object> members = new Dictionary<string, object>();

        /// <summary>
        /// Create a new ElasticSearchEntity object
        /// </summary>
        /// <param name="members">Dictionnary of index</param>
        /// <returns>ElasticSearchEntity</returns>
        public static ElasticSearchEntity CreateFrom(Dictionary<string, object> members)
        {
            var entity = new ElasticSearchEntity();
            entity.SetMembers(members);
            return entity;
        }

        /// <summary>
        /// Get the value of the class dictionnary from the index
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string GetValue(string property)
        {
            if (members.ContainsKey(property))
            {
                var tmp = members[property];
                if (tmp == null)
                    return string.Empty;
                else
                    return Convert.ToString(tmp);
            }
            return string.Empty;
        }


        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>Return the dictionnary which contains all properties and  object values</returns>
        public Dictionary<string, object> GetDictionary()
        {
            return members;
        }

        /// <summary>
        /// Set the dictionary which contains all properties and  object values
        /// </summary>
        /// <param name="members"></param>
        internal void SetMembers(Dictionary<string, object> members)
        {
            this.members = members;
        }

        /// <summary>
        /// Add a property to the dictionary if not exists else, set existing property
        /// </summary>
        /// <param name="property">Key of the dictionary(object prooperty)</param>
        /// <param name="value">Value related to the key</param>
        public void SetPropertyAndValue(string property, object value)
        {
            if (!members.ContainsKey(property))
                members.Add(property, value);
            else
                members[property] = value;
        }

        /// <summary>
        /// Method usefull to determine if the object contain in the dictionary related to the key passed into the binder,
        /// has a delegate type to call it like a method. 
        /// </summary>
        /// <param name="binder">Represents the invoke member dynamic operation at the call site</param>
        /// <param name="args">Arguments wich are contains in the delegate method</param>
        /// <param name="result">Result of the method called dynamically from the object</param>
        /// <returns>If returns true, the object can be called like a method</returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (members.ContainsKey(binder.Name)
                        && members[binder.Name] is Delegate)
            {
                result = (members[binder.Name] as Delegate).DynamicInvoke(args);
                return true;
            }
            else
            {
                return base.TryInvokeMember(binder, args, out result);
            }
        }
    }
    
}
