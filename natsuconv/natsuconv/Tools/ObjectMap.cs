﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Tools
{
	public class ObjectMap
	{
		private Dictionary<string, object> Map;

		public static ObjectMap Create()
		{
			return new ObjectMap(DictionaryTools.Create<object>());
		}

		public static ObjectMap CreateIgnoreCase()
		{
			return new ObjectMap(DictionaryTools.CreateIgnoreCase<object>());
		}

		public ObjectMap(Dictionary<string, object> map)
		{
			this.Map = map;
		}

		public void Add(Dictionary<object, object> map)
		{
			foreach (object key in map.Keys)
			{
				this.Add(key, map[key]);
			}
		}

		public void Add(object key, object value)
		{
			this.Map.Add("" + key, value);
		}

		public int GetCount()
		{
			return this.Map.Count;
		}

		public ICollection<string> GetKeys()
		{
			return this.Map.Keys;
		}

		public object GetValue(string key)
		{
			return this.Map[key];
		}

		public object this[string key]
		{
			get
			{
				return this.GetValue(key);
			}
		}
	}
}
