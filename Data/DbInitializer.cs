using MedicalExpertSystem.Models;
using MedicalExpertSystem.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(MedicalContext context)
        {
            context.Database.EnsureCreated();

            if (!context.AppUser.Any())
            {
                var appUsers = new AppUser[]
                {
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Barbara"), UserName="barbara@szweda.pl",
                            NormalizedUserName="BARBARA@SZWEDA.PL",Email="barbara@szweda.pl", NormalizedEmail="BARBARA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Anna"), UserName="anna@szweda.pl",
                            NormalizedUserName="ANNA@SZWEDA.PL",Email="anna@szweda.pl", NormalizedEmail="ANNA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Kasia"), UserName="kasia@szweda.pl",
                            NormalizedUserName="KASIA@SZWEDA.PL",Email="kasia@szweda.pl", NormalizedEmail="KASIA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Maria"), UserName="maria@szweda.pl",
                            NormalizedUserName="MARIA@SZWEDA.PL",Email="maria@szweda.pl", NormalizedEmail="MARIA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Ewa"), UserName="ewa@szweda.pl",
                            NormalizedUserName="EWA@SZWEDA.PL",Email="ewa@szweda.pl", NormalizedEmail="EWA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Kinga"), UserName="kinga@szweda.pl",
                            NormalizedUserName="KINGA@SZWEDA.PL",Email="kinga@szweda.pl", NormalizedEmail="KINGA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Elzbieta"), UserName="elzbieta@szweda.pl",
                            NormalizedUserName="ELZBIETA@SZWEDA.PL",Email="elzbieta@szweda.pl", NormalizedEmail="ELZBIETA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Krystyna"), UserName="krystyna@szweda.pl",
                            NormalizedUserName="KRYSTYNA@SZWEDA.PL",Email="krystyna@szweda.pl", NormalizedEmail="KRYSTYNA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Agnieszka"), UserName="agnieszka@szweda.pl",
                            NormalizedUserName="AGNIESZKA@SZWEDA.PL",Email="agnieszka@szweda.pl", NormalizedEmail="AGNIESZKA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Michalina"), UserName="michalina@szweda.pl",
                            NormalizedUserName="MICHALINA@SZWEDA.PL",Email="michalina@szweda.pl", NormalizedEmail="MICHALINA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Paulina"), UserName="paulina@szweda.pl",
                            NormalizedUserName="PAULINA@SZWEDA.PL",Email="paulina@szweda.pl", NormalizedEmail="PAULINA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Natalia"), UserName="natalia@szweda.pl",
                            NormalizedUserName="NATALIA@SZWEDA.PL",Email="natalia@szweda.pl", NormalizedEmail="NATALIA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Zofia"), UserName="zofia@szweda.pl",
                            NormalizedUserName="ZOFIA@SZWEDA.PL",Email="zofia@szweda.pl", NormalizedEmail="ZOFIA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Alicja"), UserName="alicja@szweda.pl",
                            NormalizedUserName="ALICJA@SZWEDA.PL",Email="alicja@szweda.pl", NormalizedEmail="ALICJA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Edyta"), UserName="edyta@szweda.pl",
                            NormalizedUserName="EDYTA@SZWEDA.PL",Email="edyta@szweda.pl", NormalizedEmail="EDYTA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Agata"), UserName="agata@szweda.pl",
                            NormalizedUserName="AGATA@SZWEDA.PL",Email="agata@szweda.pl", NormalizedEmail="AGATA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Stefania"), UserName="stefania@szweda.pl",
                            NormalizedUserName="STEFANIA@SZWEDA.PL",Email="stefania@szweda.pl", NormalizedEmail="STEFANIA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    new AppUser{LastName=RSACipher.Encrypt("Szweda"),FirstName=RSACipher.Encrypt("Ola"), UserName="ola@szweda.pl",
                            NormalizedUserName="OLA@SZWEDA.PL",Email="ola@szweda.pl", NormalizedEmail="OLA@SZWEDA.PL",
                            PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                            SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0},
                    };

                foreach (AppUser user in appUsers)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }

            if (!context.Patient.Any())
            {
                Patient[] patients = new Patient[]
                {
                    new Patient{AppUser=context.AppUser.ToList()[0]},
                    new Patient{AppUser=context.AppUser.ToList()[1]},
                    new Patient{AppUser=context.AppUser.ToList()[2]},
                    new Patient{AppUser=context.AppUser.ToList()[3]},
                    new Patient{AppUser=context.AppUser.ToList()[4]},
                    new Patient{AppUser=context.AppUser.ToList()[5]},
                    new Patient{AppUser=context.AppUser.ToList()[6]},
                    new Patient{AppUser=context.AppUser.ToList()[7]},
                    new Patient{AppUser=context.AppUser.ToList()[8]},
                    new Patient{AppUser=context.AppUser.ToList()[9]},
                    new Patient{AppUser=context.AppUser.ToList()[10]},
                    new Patient{AppUser=context.AppUser.ToList()[11]},
                    new Patient{AppUser=context.AppUser.ToList()[12]},
                    new Patient{AppUser=context.AppUser.ToList()[13]},
                    new Patient{AppUser=context.AppUser.ToList()[14]},
                    new Patient{AppUser=context.AppUser.ToList()[15]},
                    new Patient{AppUser=context.AppUser.ToList()[16]}
                };

                foreach (Patient patient in patients)
                {
                    context.Patient.Add(patient);
                }

                context.SaveChanges();
            }

            if (!context.MedicalData.Any())
            {
                MedicalData[] medicalData = new MedicalData[]
                {
                    new MedicalData{Pregnancies=6,Glucose=85,BloodPressure=90,SkinThickness=35,Insulin=94,DiabetesPedigreeFunction=0.627,Bmi=26.6,Age=60, Patient = context.Patient.ToList()[0]},
                    new MedicalData{Pregnancies=4,Glucose=10,BloodPressure=70,SkinThickness=40,Insulin=194,DiabetesPedigreeFunction=0.123,Bmi=28.7,Age=57, Patient = context.Patient.ToList()[1]},
                    new MedicalData{Pregnancies=1,Glucose=85,BloodPressure=60,SkinThickness=10,Insulin=74,DiabetesPedigreeFunction=0.627,Bmi=23.6,Age=23, Patient = context.Patient.ToList()[2]},
                    new MedicalData{Pregnancies=0,Glucose=99,BloodPressure=66,SkinThickness=5,Insulin=36,DiabetesPedigreeFunction=0.123,Bmi=19.6,Age=18, Patient = context.Patient.ToList()[3]},
                    new MedicalData{Pregnancies=5,Glucose=113,BloodPressure=90,SkinThickness=45,Insulin=94,DiabetesPedigreeFunction=0.627,Bmi=34.6,Age=66, Patient = context.Patient.ToList()[4]},
                    new MedicalData{Pregnancies=2,Glucose=180,BloodPressure=77,SkinThickness=35,Insulin=94,DiabetesPedigreeFunction=1.627,Bmi=20.6,Age=32, Patient = context.Patient.ToList()[5]},
                    new MedicalData{Pregnancies=1,Glucose=89,BloodPressure=70,SkinThickness=25,Insulin=94,DiabetesPedigreeFunction=0.123,Bmi=28.6,Age=44, Patient = context.Patient.ToList()[6]},
                    new MedicalData{Pregnancies=8,Glucose=158,BloodPressure=75,SkinThickness=35,Insulin=94,DiabetesPedigreeFunction=0.627,Bmi=31.6,Age=63, Patient = context.Patient.ToList()[7]},
                    new MedicalData{Pregnancies=5,Glucose=112,BloodPressure=88,SkinThickness=25,Insulin=194,DiabetesPedigreeFunction=0.627,Bmi=26.6,Age=58, Patient = context.Patient.ToList()[8]},
                    new MedicalData{Pregnancies=4,Glucose=88,BloodPressure=76,SkinThickness=35,Insulin=78,DiabetesPedigreeFunction=0.627,Bmi=26.6,Age=39, Patient = context.Patient.ToList()[9]},
                    new MedicalData{Pregnancies=0,Glucose=85,BloodPressure=78,SkinThickness=35,Insulin=32,DiabetesPedigreeFunction=0.627,Bmi=28.6,Age=47, Patient = context.Patient.ToList()[10]},
                    new MedicalData{Pregnancies=0,Glucose=80,BloodPressure=66,SkinThickness=10,Insulin=56,DiabetesPedigreeFunction=1.627,Bmi=23.7,Age=21, Patient = context.Patient.ToList()[11]},
                    new MedicalData{Pregnancies=1,Glucose=155,BloodPressure=77,SkinThickness=35,Insulin=74,DiabetesPedigreeFunction=0.627,Bmi=27.6,Age=55, Patient = context.Patient.ToList()[12]},
                    new MedicalData{Pregnancies=1,Glucose=115,BloodPressure=74,SkinThickness=25,Insulin=94,DiabetesPedigreeFunction=0.627,Bmi=26.6,Age=47, Patient = context.Patient.ToList()[13]},
                    new MedicalData{Pregnancies=3,Glucose=185,BloodPressure=88,SkinThickness=35,Insulin=94,DiabetesPedigreeFunction=0.627,Bmi=29.6,Age=47, Patient = context.Patient.ToList()[14]},
                    new MedicalData{Pregnancies=2,Glucose=86,BloodPressure=69,SkinThickness=46,Insulin=104,DiabetesPedigreeFunction=0.627,Bmi=36.6,Age=47, Patient = context.Patient.ToList()[15]},
                    new MedicalData{Pregnancies=5,Glucose=185,BloodPressure=89,SkinThickness=33,Insulin=194,DiabetesPedigreeFunction=0.627,Bmi=29.6,Age=58, Patient = context.Patient.ToList()[16]}
                };

                foreach (MedicalData data in medicalData)
                {
                    context.MedicalData.Add(data);
                }

                context.SaveChanges();
            }
        }

        //public static void PredictSeededMedData(MedicalContext context)
        //{
        //    List<MedicalData> medData = context.MedicalData.ToList();

        //    foreach (var data in medData)
        //    {
        //        data.Prediction = 
        //    }
        //}
    }
}