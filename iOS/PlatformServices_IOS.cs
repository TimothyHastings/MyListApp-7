//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Dr Tim Hastings.
//

using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using MyListApp;

[assembly: Dependency (typeof (PlatformServices_IOS))]
/// <summary>
/// SQlite IO.
/// </summary>
public class PlatformServices_IOS : IPlatformServices {
	public PlatformServices_IOS () {}

	/// <summary>
	/// Gets the connection.
	/// </summary>
	/// <returns>The connection.</returns>
	/// <param name="dbName">Db name.</param>
	public SQLite.SQLiteConnection GetConnection (String dbName)
	{
		var path = GetFilePath(dbName);
		SQLiteConnection connection = new SQLiteConnection(path);
		return (connection);
	}

	/// <summary>
	/// Deletes the database.
	/// </summary>
	/// <param name="dbname">Dbname.</param>
	public bool DeleteDatabase(string dbname)
	{
		var filePath = GetFilePath(dbname);
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Test if the Database exists.
	/// </summary>
	/// <returns><c>true</c>, if exists was databased, <c>false</c> otherwise.</returns>
	/// <param name="dbname">Dbname.</param>
	public bool DatabaseExists(string dbname)
	{
		if (File.Exists(GetFilePath(dbname)))
			return true;
		return false;
	}

	private string GetFilePath(string fileName)
	{
		var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		var filePath = Path.Combine(documentsPath, fileName);
		return filePath;
	}
}		

