using System;
using System.Collections.Generic;
using System.Text;

namespace NotifyTest {
	/// <summary>
	/// This class is used to test the functionality of
	/// <see cref="T:PropertyNotificationObject"/> and
	/// <see cref="T:IPropertyNotification"/>.
	/// </summary>
	public class TestObject : PropertyNotificationObject {
		#region Properties

		/// <summary>
		/// Holds the name.
		/// </summary>
		private String name = String.Empty;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public String Name {
			get {
				return this.name;
			}
			set {
				SetProperty<String>("Name", ref this.name, value);
			}
		}

		#endregion // Properties
	}
}
