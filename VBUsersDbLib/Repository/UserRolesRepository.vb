Imports System.Data.SqlClient
Imports System.Numerics
Imports VBUsersDbLib.Context
Imports VBUsersDbLib.Model

Namespace Repository
    Public Class UserRolesRepository
        Implements IUserRolesRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function CreateUserRole(usro As User_roles) As User_roles Implements IUserRolesRepository.CreateUserRole
            Dim newUserRoles As New User_roles()

            'declare stmt
            Dim stmt As String = "Insert into users.user_roles(usro_user_id,usro_role_id) values (@usro_user_id,@usro_role_id)"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@usro_user_id", usro.UsroUserId)
                    cmd.Parameters.AddWithValue("@usro_role_id", usro.UsroRoleId)

                    Try
                        conn.Open()
                        'Executescalar return 1 row & get first column
                        Dim regionId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newUserRoles = FindUserRoleById(usro.UsroUserId)

                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newUserRoles
        End Function

        Public Function DeleteUserRole(id As Integer) As Integer Implements IUserRolesRepository.DeleteUserRole
            Dim rowEffect As Int32 = 0

            'declare stmt
            Dim stmt As String = "delete from users.user_roles where usro_user_id = @usroUserId"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@usroUserId", id)


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

        Public Function FindAllUserRole() As List(Of User_roles) Implements IUserRolesRepository.FindAllUserRole
            Dim userRoleList As New List(Of User_roles)

            'declare statement
            Dim sql As String = "SELECT usro_user_id, usro_role_id from users.user_roles " &
                                "Order by usro_user_id desc;"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            userRoleList.Add(New User_roles() With {
                                .UsroUserId = reader.GetInt32(0),
                                .UsroRoleId = reader.GetInt32(1)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return userRoleList
        End Function

        Public Function FindAllUserRoleAsync() As Task(Of List(Of User_roles)) Implements IUserRolesRepository.FindAllUserRoleAsync
            Throw New NotImplementedException()
        End Function

        Public Function FindUserRoleById(id As Integer) As User_roles Implements IUserRolesRepository.FindUserRoleById
            Dim userRoles As New User_roles With {.UsroRoleId = id}

            'sql statement
            Dim stmt As String = "SELECT usro_user_id, usro_role_id from users.user_roles " &
                                 "where usro_user_id = @usroUserId;"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@usroUserId", id)

                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            userRoles.UsroRoleId = reader.GetInt32(1)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception

                    End Try
                End Using
            End Using
            Return userRoles
        End Function

        Public Function UpdateUserRoleById(id As Integer, value As Integer, Optional showCommand As Boolean = False) As Boolean Implements IUserRolesRepository.UpdateUserRoleById
            Dim updateUserRoles As New User_roles()

            'declare stmt
            Dim stmt As String = "Update users.user_roles " &
                                 "set " &
                                 "usro_role_id = @usro_role_id " &
                                 "where usro_user_id = @usro_user_id;"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@usro_user_id", id)
                    cmd.Parameters.AddWithValue("@usro_role_id", value)


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

        Public Function UpdateUserRoleBySp(id As Integer, value As Integer, Optional showCommand As Boolean = False) As Boolean Implements IUserRolesRepository.UpdateUserRoleBySp
            Dim updateUsro As New User_roles()

            'declare stmt
            Dim stmt As String = "users.spUpdateUsro"


            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@usro_user_id", id)
                    cmd.Parameters.AddWithValue("@usro_role_id", value)


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
    End Class
End Namespace
