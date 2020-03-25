﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //calDOB.Visible = false;
                hyperLinkSignIn.Visible = false;
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string sex = "";
            string maritalStatus = "";
            string occupation = "";
            string medInfo = "";
            string email = "";
            string dob;

            string name = tbName.Text;
            string address = tbAdress.Text;
            string contactNo = tbContactNo.Text;
            int age = Convert.ToInt32(tbAge.Value);
            email = tbEmail.Text;
            dob = Convert.ToDateTime(tbDOB.Value).ToString("yyyy/MM/dd");

            sex = ddlSex.SelectedValue;
            maritalStatus = ddlMaritalStatus.SelectedValue;
            occupation = ddlOccupation.SelectedValue;

            if (tbSensitivityTo.Text.Length > 0) medInfo += ("Sensitivity To: " + tbSensitivityTo.Text + "\n");
            if (tbAllergicTo.Text.Length > 0) medInfo += "Allergic To: " + tbAllergicTo.Text + "\n";
            if (tbMedicine.Text.Length > 0) medInfo += "Taking Medicine: " + tbMedicine.Text + "\n";

            //checkBox
            medInfo += "Other Medical Details:" + "\n";
            if (cbBadCondition.Checked == true) medInfo += "Bad Condition\n";

            if (cbGumBleeds.Checked == true) medInfo += "Gum Bleeding\n";

            if (cbToothLoose.Checked == true) medInfo += "Loose Tooth\n";

            if (cbChestPain.Checked == true) medInfo += "Chest Pain\n"; ;

            if (cbGumDisease.Checked == true) medInfo += "Gum Disease\n";

            if (cbBadBreath.Checked == true) medInfo += "Bad Breath\n";

            if (cbJawpain.Checked == true) medInfo += "Jaw Pain\n";

            if (cbBleedingTend.Checked == true) medInfo += "Bleeding Tendency\n";

            if (cbHepatitis.Checked == true) medInfo += "Hepatitis\n";

            if (cbHighBP.Checked == true) medInfo += "High BP\n";

            if (cbDiabetes.Checked == true) medInfo += "Diabetes\n";

            if (cbKidneyDisease.Checked == true) medInfo += "Kidney Disease\n";

            if (cbHeartTrouble.Checked == true) medInfo += "Heart Trouble\n";

            if (cbLiverDisease.Checked == true) medInfo += "Liver Disease\n";

            if (cbLungDisease.Checked == true) medInfo += "Lung Disease\n";

            if (cbAsthma.Checked == true) medInfo += "Asthma\n";

            if (cbRheumatic.Checked == true) medInfo += "Rheumatic Fever\n";

            if (cbAIDS.Checked == true) medInfo += "AIDS\n";

            if (cbAnemia.Checked == true) medInfo += "Amenia\n";
            if (cbPregnant.Checked == true) medInfo += "Pregnant\n";

            if (new PatientDAO().createPatient(new PatientDTO(name, address, contactNo, age, sex, maritalStatus, occupation, medInfo, email, dob)))
            {
                int id = new PatientDAO().getID(email);
                lblMessage.Text = "Your  Patient Id is " + id;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Session["PatientID"] = id;
                hyperLinkSignIn.Visible = true;
            }
            else
            {
                lblMessage.Text = " Something went wrong, please try again";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //protected void calDOB_SelectionChanged(object sender, EventArgs e)
        //{
        //    tbDOB.Text = calDOB.SelectedDate.ToShortDateString();
        //    calDOB.Visible = false;
        //}

        //protected void imgBtnCalDOB_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (calDOB.Visible == false)
        //    {
        //        calDOB.Visible = true;
        //    }
        //    else
        //    {
        //        calDOB.Visible = false;
        //    }
        //}

        //protected void tbDOB_TextChanged(object sender, EventArgs e)
        //{
        //    calDOB.SelectedDate = Convert.ToDateTime(tbDOB.Text);
        //}

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}