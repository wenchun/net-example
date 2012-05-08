using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MSNPSharp;
using MSNPSharp.Core;


namespace MsnDemo
{
	/// <summary>
	/// 一個簡單的 MSN 即時訊息發送類別。
	/// 用途：登入 MSN 即時訊息伺服器、發送文字訊息給特定聯絡人（對方必須在線上）。
	/// 
	/// Written by Huan-Lin Tsai. Dec-10-2008.
	/// </summary>
	public class SimpleMsnMessenger
	{
		private Messenger messenger;

		private List<Exception> errors;
		private Queue<string> msgQueue;	// 欲傳送的訊息佇列.
		TextMessage txtMsg;				// 文字訊息物件.

		bool isConnecting;

		public SimpleMsnMessenger()
		{
			messenger = new Messenger();

			// by default this example will emulate the official microsoft windows messenger client
			messenger.Credentials = new Credentials("PROD0119GSJUC$18", "ILTXC!4IXB5FB*PX");

			// uncomment this to enable verbose output for debugging
			Settings.TraceSwitch.Level = System.Diagnostics.TraceLevel.Verbose;

			// set the events that we will handle
			// remember that the nameserver is the server that sends contact lists, notifies you of contact status changes, etc.
			// a switchboard server handles the individual conversation sessions.
			messenger.ConnectionEstablished += new EventHandler<EventArgs>(NameserverProcessor_ConnectionEstablished);
			messenger.ConnectingException += new EventHandler<ExceptionEventArgs>(NameserverProcessor_ConnectingException);
			messenger.Nameserver.SignedIn += new EventHandler<EventArgs>(Nameserver_SignedIn);
			messenger.Nameserver.AuthenticationError += new EventHandler<ExceptionEventArgs>(Nameserver_AuthenticationError);
			messenger.Nameserver.ExceptionOccurred += new EventHandler<ExceptionEventArgs>(Nameserver_ExceptionOccurred);

			//messenger.ConversationCreated += new ConversationCreatedEventHandler(messenger_ConversationCreated);

			msgQueue = new Queue<string>();

			txtMsg = new TextMessage();
			txtMsg.Font = "Trebuchet MS";
			txtMsg.Color = Color.Black;
			txtMsg.Decorations = TextDecorations.Bold;

			errors = new List<Exception>();
		}

		public SimpleMsnMessenger(string email, string password) : this()
		{
			// set the credentials, this is ofcourse something every MSNPSharp program will need to
			// implement.
			messenger.Credentials.Account = email;
			messenger.Credentials.Password = password;
		}

		void Nameserver_AuthenticationError(object sender, ExceptionEventArgs e)
		{
			errors.Add(e.Exception);
		}

		void NameserverProcessor_ConnectingException(object sender, ExceptionEventArgs e)
		{
			errors.Add(e.Exception);
			isConnecting = false;
		}

		void NameserverProcessor_ConnectionException(object sender, ExceptionEventArgs e)
		{
			errors.Add(e.Exception);
		}

		void Nameserver_ExceptionOccurred(object sender, ExceptionEventArgs e)
		{
			errors.Add(e.Exception);
		}

		private void NameserverProcessor_ConnectionEstablished(object sender, EventArgs e)
		{
		}


		public void Connect()
		{
			errors.Clear();

			isConnecting = true;
			messenger.Connect();
		}

		public void Disconnect()
		{
            //if (conversation != null)
            //{
            //    conversation.Switchboard.Close();
            //}

			if (messenger.Connected)
			{
				messenger.Disconnect();
			}
		}

		private void Nameserver_SignedIn(object sender, EventArgs e)
		{
			isConnecting = false;
			messenger.Owner.Status = PresenceStatus.Online;

			//SetStatus("成功登入 MSN 網路，身分為: " + messenger.Owner.Name);
		}

		public void SendTextMessage(string contactEmail, string text)
		{
            //conversation = messenger.CreateConversation();

            //conversation.Switchboard.SessionClosed += new SBChangedEventHandler(Switchboard_SessionClosed);
            //conversation.Switchboard.ContactJoined += new ContactChangedEventHandler(Switchboard_ContactJoined);
            ////conversation.Switchboard.ContactLeft += new ContactChangedEventHandler(Switchboard_ContactLeft);

            //// 加入訊息佇列
            //msgQueue.Enqueue(contactEmail + "=" + text);

            //conversation.Invite(contactEmail, ClientType.PassportMember);
		}

		private void Switchboard_SessionClosed(object sender, EventArgs e)
		{
		}

		private void Switchboard_ContactJoined(object sender, ContactEventArgs e)
		{
			InternalSendTextMessage(e.Contact);			
		}

		private void InternalSendTextMessage(Contact contact)
		{
			//SetStatus("傳送訊息給 " + contact.Name);
			string targetMsg;
			string email;
			int i;

			while (msgQueue.Count > 0) 
			{
				targetMsg = msgQueue.Dequeue();
				i = targetMsg.IndexOf('=');
				if (i >= 0)
				{
					email = targetMsg.Substring(0, i).ToLower();
					if (email.Equals(contact.Account.ToLower()))	// 比對是否為訊息目標
					{
						txtMsg.Text = targetMsg.Substring(i + 1);
                        //conversation.Switchboard.SendTextMessage(txtMsg);
					}
				}			
			}
		}


		#region 屬性

		public string Account
		{
			get
			{
				return messenger.Credentials.Account;
			}
			set
			{
				messenger.Credentials.Account = value;
			}
		}

		public string Password
		{
			get
			{
				return messenger.Credentials.Password;
			}
			set
			{
				messenger.Credentials.Password = value;
			}
		}

		public bool Connected
		{
			get
			{
				return messenger.Connected;
			}
		}

		public bool SignedIn
		{
			get
			{
				return messenger.Nameserver.IsSignedIn;
			}
		}

		public bool IsConnecting
		{
			get
			{
				return isConnecting;
			}
		}

		public int ErrorCount
		{
			get
			{
				return errors.Count;
			}
		}

		public Exception LastError
		{
			get
			{
				if (errors.Count == 0)
				{
					return null;
				}
				return errors[errors.Count-1];
			}
		}

		public bool MessageQueueEmpty
		{
			get
			{
				return (msgQueue.Count == 0);
			}
		}
		#endregion 屬性
	}
}
