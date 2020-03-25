using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCMSDataAccessLayer
{
    public class TreatmentPlanningDTO
    {
        string tooth = "", date = "", treatment = "";

        int pID, dID, quantity, cost, paid;

        public string Treatment
        {
            get { return treatment; }
            set { treatment = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public int Paid
        {
            get { return paid; }
            set { paid = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int DID
        {
            get { return dID; }
            set { dID = value; }
        }

        public int PID
        {
            get { return pID; }
            set { pID = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Tooth
        {
            get { return tooth; }
            set { tooth = value; }
        }
        public TreatmentPlanningDTO(string treatment, int pID, int dID, string tooth, int quantity, int cost, int paid)
        {
            this.treatment = treatment;
            this.pID = pID;
            this.dID = dID;
            this.tooth = tooth;
            this.quantity = quantity;
            this.cost = cost;
            this.paid = paid;
            this.date = System.DateTime.Today.AddDays(0).ToString("dd-MM-yyyy");
        }
    }
}