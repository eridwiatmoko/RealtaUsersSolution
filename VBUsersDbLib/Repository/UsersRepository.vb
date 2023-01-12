Imports System.Data.SqlClient
Imports VBUsersDbLib.Context
Imports VBUsersDbLib.Model

Namespace Repository
    Public Class UsersRepository
        Implements IUsersRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateUser(users As Users) As Users Implements IUsersRepository.CreateUser
            Dim newUser As New Users()

            'declare stmt
            Dim stmt As String = "Insert into users.users(user_full_name,user_type," &
                                 "user_company_name,user_email,user_phone_number,user_modified_date) " &
                                 "values (@user_full_name,@user_type,@user_company_name, " &
                                 "@user_email,@user_phone_number,@user_modified_date); " &
                                 "Select ident_current('users.users');"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@user_full_name", users.UserFullName)
                    cmd.Parameters.AddWithValue("@user_type", users.UserType)
                    cmd.Parameters.AddWithValue("@user_company_name", users.UserCompanyName)
                    cmd.Parameters.AddWithValue("@user_email", users.UserEmail)
                    cmd.Parameters.AddWithValue("@user_phone_number", users.UserPhoneNumber)
                    cmd.Parameters.AddWithValue("@user_modified_date", users.UserModifiedDate)

                    Try
                        conn.Open()
                        'Executescalar return 1 row & get first column
                        Dim userId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newUser = FindUserById(userId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newUser
        End Function

        Public Function DeleteUser(id As Integer) As Integer Implements IUsersRepository.DeleteUser
            Dim rowEffect As Int32 = 0

            'declare stmt
            Dim stmt As String = "delete from users.users where user_id = @userId"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@userId", id)


                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return rowEffect
        End Function

        Public Function FindAllUser() As List(Of Users) Implements IUsersRepository.FindAllUser
            Dim userList As New List(Of Users)

            'declare statement
            Dim sql As String = "SELECT user_id,user_full_name,user_type,user_company_name,user_email,user_phone_number,user_modified_date from users.users " &
                                "Order by user_id desc;"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            userList.Add(New Users() With {
                                .UserId = reader.GetInt32(0),
                                .UserFullName = reader.GetString(1),
                                .UserType = reader.GetString(2),
                                .UserCompanyName = reader.GetString(3),
                                .UserEmail = reader.GetString(4),
                                .UserPhoneNumber = reader.GetString(5),
                                .UserModifiedDate = reader.GetDateTime(6)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return userList
        End Function

        Public Function FindUserById(id As Integer) As Users Implements IUsersRepository.FindUserById
            Dim users As New Users With {.UserId = id}

            'sql statement
            Dim stmt As String = "SELECT user_id,user_full_name,user_type,user_company_name,user_email,user_phone_number,user_modified_date from users.users " &
                                 "where user_id = @userId;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@userId", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            users.UserFullName = reader.GetString(1)
                            users.UserType = reader.GetString(2)
                            users.UserCompanyName = reader.GetString(3)
                            users.UserEmail = reader.GetString(4)
                            users.UserPhoneNumber = reader.GetString(5)
                            users.UserModifiedDate = reader.GetDateTime(6)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception

                    End Try
                End Using
            End Using
            Return users
        End Function

        Public Function UpdateUserById(id As Integer, name As String, type As String, company As String, email As String, phone As String, Optional showCommand As Boolean = False) As Boolean Implements IUsersRepository.UpdateUserById
            Dim updateUser As New Users()

            'declare stmt
            Dim stmt As String = "Update users.users " &
                                 "set " &
                                 "user_full_name = @user_full_name," &
                                 "user_type = @user_type," &
                                 "user_company_name = @user_company_name," &
                                 "user_email = @user_email," &
                                 "user_phone_number = @user_phone_number " &
                                 "where user_id = @user_id;"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@user_id", id)
                    cmd.Parameters.AddWithValue("@user_full_name", name)
                    cmd.Parameters.AddWithValue("@user_type", type)
                    cmd.Parameters.AddWithValue("@user_company_name", company)
                    cmd.Parameters.AddWithValue("@user_email", email)
                    cmd.Parameters.AddWithValue("@user_phone_number", phone)

                    'show command
                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function

        Public Function UpdateUserBySp(id As Integer, name As String, type As String, company As String, email As String, phone As String, Optional showCommand As Boolean = False) As Boolean Implements IUsersRepository.UpdateUserBySp
            Dim updateUser As New Users()

            'declare stmt
            Dim stmt As String = "users.spUpdateUser"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@user_id", id)
                    cmd.Parameters.AddWithValue("@user_full_name", name)
                    cmd.Parameters.AddWithValue("@user_type", type)
                    cmd.Parameters.AddWithValue("@user_company_name", company)
                    cmd.Parameters.AddWithValue("@user_email", email)
                    cmd.Parameters.AddWithValue("@user_phone_number", phone)

                    'show command
                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function

        Public Async Function FindAllUserAsync() As Task(Of List(Of Users)) Implements IUsersRepository.FindAllUserAsync
            Dim userList As New List(Of Users)

            'declare statement
            Dim sql As String = "SELECT user_id,user_full_name,user_type,user_company_name,user_email,user_phone_number,user_modified_date from users.users " &
                                "Order by user_id desc;"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            userList.Add(New Users() With {
                                .UserId = reader.GetInt32(0),
                                .UserFullName = reader.GetString(1),
                                .UserType = reader.GetString(2),
                                .UserCompanyName = reader.GetString(3),
                                .UserEmail = reader.GetString(4),
                                .UserPhoneNumber = reader.GetString(5),
                                .UserModifiedDate = reader.GetDateTime(6)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return userList
        End Function
    End Class
End Namespace
