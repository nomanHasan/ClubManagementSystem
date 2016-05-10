using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models.Repository
{
    public class Repository
    {
        static string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        static SqlConnection conn = new SqlConnection(connStr);
        static SqlDataAdapter adapter;

        public static DataSet GetDataSet(string sqlString, string tableName) {
            DataSet returnDataSet = new DataSet();
            adapter = new SqlDataAdapter(sqlString, connStr);
            adapter.Fill(returnDataSet, tableName);

            return returnDataSet;
        }

        public static int InsertDataSet(string sqlString)
        {
            int status;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlString, conn);

            status = cmd.ExecuteNonQuery();

            conn.Close();
            return status;
        }

        public static object ExecuteScalar(string sqlString) {
            object ob;
            using (SqlConnection conn = new SqlConnection(connStr)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                ob = cmd.ExecuteScalar();
                conn.Close();
            }
            return ob;
        }

        public static int insertClub(string clubName, string clubDetails, DateTime thisTime) {
            int status;
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into club (ClubName, ClubDetails, ClubCreated) values(@Name,@Details,@Date)", conn);

            SqlParameter name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            SqlParameter details = new SqlParameter("@Details", SqlDbType.NVarChar, 50);
            SqlParameter datetime = new SqlParameter("@Date", SqlDbType.DateTime);

            name.Value = clubName;
            details.Value = clubDetails;
            datetime.Value = DateTime.Now;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(details);
            cmd.Parameters.Add(datetime);


            status = cmd.ExecuteNonQuery();

            conn.Close();
            return status;
        }

        public static int deleteClub(int clubID) {
            int status;
            using (SqlConnection conn = new SqlConnection(connStr)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from club where clubID = @ID", conn);

                SqlParameter id = new SqlParameter("@ID", SqlDbType.Int);

                id.Value = clubID;
                cmd.Parameters.Add(id);
                status = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("delete from president where clubID = @ID", conn);
                id = new SqlParameter("@ID", SqlDbType.Int);
                id.Value = clubID;
                cmd.Parameters.Add(id);
                status = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("delete from event where clubID = @ID", conn);
                id = new SqlParameter("@ID", SqlDbType.Int);
                id.Value = clubID;
                cmd.Parameters.Add(id);
                status = cmd.ExecuteNonQuery();


                conn.Close();
            }

            return status;
        }

        public static int updateClub(int clubID, string clubName, string clubDetails, string clubCreated) {
            int status;
            using (SqlConnection conn = new SqlConnection(connStr)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update club set clubName=@Name, clubDetails = @Details, clubCreated = @Date where clubID = @ID", conn);

                SqlParameter id = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter name = new SqlParameter("@Name", SqlDbType.NVarChar);
                SqlParameter details = new SqlParameter("@Details", SqlDbType.NVarChar);
                SqlParameter dateCreated = new SqlParameter("@Date", SqlDbType.DateTime);


                id.Value = clubID;
                name.Value = clubName;
                details.Value = clubDetails;
                dateCreated.Value = Convert.ToDateTime(clubCreated);

                cmd.Parameters.Add(id);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(details);
                cmd.Parameters.Add(dateCreated);

                status = cmd.ExecuteNonQuery();

            }

            return status;
        }

        public static int addPresident(int studentID, int clubID) {
            int status = 0;

            DataSet d = GetDataSet(string.Format("select * from president where studentID={0}", studentID), "data");

            if (d.Tables["data"].Rows.Count == 0) {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into president (studentID, clubID) values(@SID, @CID)", conn);

                    SqlParameter sid = new SqlParameter("@SID", SqlDbType.Int);
                    SqlParameter cid = new SqlParameter("@CID", SqlDbType.Int);

                    sid.Value = studentID;
                    cid.Value = clubID;

                    cmd.Parameters.Add(sid);
                    cmd.Parameters.Add(cid);

                    status = cmd.ExecuteNonQuery();

                    SqlCommand sqlCommand = new SqlCommand("update Account set role='president' where username in (select username from student where studentID = @STID)", conn);

                    SqlParameter stid = new SqlParameter("@STID", SqlDbType.Int);
                    stid.Value = studentID;

                    sqlCommand.Parameters.Add(stid);

                    status = sqlCommand.ExecuteNonQuery();

                }

            }
            return status;
        }

        public static int removePresident(int studentID, int clubID) {
            int status;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("delete from president where studentID=@SID and clubID=@CID", conn);

                SqlParameter sid = new SqlParameter("@SID", SqlDbType.Int);
                SqlParameter cid = new SqlParameter("@CID", SqlDbType.Int);

                sid.Value = studentID;
                cid.Value = clubID;

                cmd.Parameters.Add(sid);
                cmd.Parameters.Add(cid);

                status = cmd.ExecuteNonQuery();


                SqlCommand sqlCommand = new SqlCommand("update Account set role='student' where username in (select username from student where studentID = @STID)", conn);

                SqlParameter stid = new SqlParameter("@STID", SqlDbType.Int);
                stid.Value = studentID;

                sqlCommand.Parameters.Add(stid);

                status = sqlCommand.ExecuteNonQuery();

            }
            return status;
        }

        public static int insertStudent(string studentName, string studentEmail, string studentPhone, string studentUsername)
        {
            int status;
            using (SqlConnection conn = new SqlConnection(connStr)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into student (studentName, Username, Email, Phone) values(@Name,@Username,@Email,@Phone)", conn);

                SqlParameter name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                SqlParameter username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                SqlParameter email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                SqlParameter phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);

                name.Value = studentName;
                username.Value = studentUsername;
                email.Value = studentEmail;
                phone.Value = studentPhone;


                cmd.Parameters.Add(name);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(phone);


                status = cmd.ExecuteNonQuery();

                conn.Close();
            }
            
            return status;
        }

        public static int insertAccount(string username, string password, string role)
        {
            int status;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Account (Username, Password, Role) values(@Username,@Password,@Role)", conn);

                SqlParameter UsernameP = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                SqlParameter PasswordP = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                SqlParameter RoleP = new SqlParameter("@Role", SqlDbType.NVarChar, 50);

                UsernameP.Value = username;
                PasswordP.Value = password;
                RoleP.Value = role;



                cmd.Parameters.Add(UsernameP);
                cmd.Parameters.Add(PasswordP);
                cmd.Parameters.Add(RoleP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;
        }

        public static int registerStudent(string studentName, string studentEmail, string studentPhone, string studentUsername, string studentPassword) {
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(username) from Account  where username = '{0}'", studentUsername)));

            if (availability > 0)
            {
                return 0;
            }

            int status1= insertStudent(studentName, studentEmail, studentPhone, studentUsername);

            int status2 = insertAccount(studentUsername, studentPassword, "student");

            if (status1 > 0 && status2 > 0)
            {
                return 1;
            }
            else {
                return 0;
            }


        }

        public static int requestMembership(int clubID, int studentID) {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from clubMembership  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability > 0)
            {
                return 0;
            }

             availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from MembershipQueue  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability > 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into membershipQueue (clubID, studentID) values(@CID,@SID)", conn);

                SqlParameter clubIDP = new SqlParameter("@CID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                clubIDP.Value = clubID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(clubIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;

        }

        public static int deleteRequestMembership(int clubID, int studentID)
        {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from clubMembership  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability > 0)
            {
                return 0;
            }

            availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from MembershipQueue  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability <= 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from membershipQueue where studentID=@SID and clubID = @CID", conn);

                SqlParameter clubIDP = new SqlParameter("@CID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                clubIDP.Value = clubID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(clubIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;

        }

        public static int deleteMembership(int clubID, int studentID)
        {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from clubMembership  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability <= 0)
            {
                return 0;
            }

            availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from MembershipQueue  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability > 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from ClubMembership where studentID=@SID and clubID = @CID", conn);

                SqlParameter clubIDP = new SqlParameter("@CID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                clubIDP.Value = clubID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(clubIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;

        }

        public static int requestParticipation(int eventID, int studentID)
        {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from eventParticipation  where studentID = {0} and eventID={1}", studentID, eventID)));

            if (availability > 0)
            {
                return 0;
            }

            availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from ParticipationQueue  where studentID = {0} and eventID={1}", studentID, eventID)));

            if (availability > 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into participationQueue (eventID, studentID) values(@EID,@SID)", conn);

                SqlParameter eventIDP = new SqlParameter("@EID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                eventIDP.Value = eventID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(eventIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;

        }

        public static int deleteRequestParticipation(int eventID, int studentID)
        {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from eventParticipation  where studentID = {0} and eventID={1}", studentID, eventID)));

            if (availability > 0)
            {
                return 0;
            }

            availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from ParticipationQueue  where studentID = {0} and eventID={1}", studentID, eventID)));

            if (availability <= 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from participationQueue where eventID=@EID and studentID=@SID", conn);

                SqlParameter eventIDP = new SqlParameter("@EID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                eventIDP.Value = eventID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(eventIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return status;
        }

        public static int acceptRequest(int clubID, int studentID) {
            int status;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from clubmembership  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability > 0)
            {
                return 0;
            }

            availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(studentID) from membershipQueue  where studentID = {0} and clubID={1}", studentID, clubID)));

            if (availability <= 0)
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from membershipqueue where clubID=@CID and studentID=@SID", conn);

                SqlParameter clubIDP = new SqlParameter("@CID", SqlDbType.Int);
                SqlParameter studentIDP = new SqlParameter("@SID", SqlDbType.Int);

                clubIDP.Value = clubID;
                studentIDP.Value = studentID;


                cmd.Parameters.Add(clubIDP);
                cmd.Parameters.Add(studentIDP);

                status = cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("insert into clubMembership (clubID, studentID, datejoined) values(@CID,@SID,@DATE)", conn);

                SqlParameter clubIDP2 = new SqlParameter("@CID", SqlDbType.Int);
                SqlParameter studentIDP2 = new SqlParameter("@SID", SqlDbType.Int);
                SqlParameter dateP = new SqlParameter("@DATE", SqlDbType.DateTime);

                clubIDP2.Value = clubID;
                studentIDP2.Value = studentID;
                dateP.Value = DateTime.Now;

                cmd2.Parameters.Add(clubIDP2);
                cmd2.Parameters.Add(studentIDP2);
                cmd2.Parameters.Add(dateP);

                status = cmd2.ExecuteNonQuery();


                conn.Close();


            }

            return status;

        }
        


    }
}