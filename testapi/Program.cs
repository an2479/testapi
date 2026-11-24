using ApiInterface;
using Model;

namespace testapi
{
    internal class Program
    {     
        static async Task Main(string[] args)
        {
            //Apiservice apiService = new Apiservice();
            //CityTblList d = await apiService.GetAllCities();
            //foreach(CityTbl city in d)
            //{
            //    await Console.Out.WriteLineAsync(city.CityName);
            //}

            //Apiservice apiservice = new();
            //CityTblList cities = await apiservice.GetAllCities();
            //Console.WriteLine(cities.Count);
            //int id = cities.Last().Id;
            //await apiservice.DeleteACity(id);
            //Console.WriteLine(cities.Count);

            //CityTbl c1 = new CityTbl() { CityName = "Natania" };
            //await apiservice.InsertACity(c1);
            //CityTbl myCity = cities.First();
            //myCity.CityName = "Eilat";
            //await apiservice.UpdateACity(myCity);

            Apiservice apiservice = new Apiservice();

            // CITIES
            Console.WriteLine("===== CITIES =====");

            CityTblList cities = await apiservice.GetAllCities();
            Console.WriteLine("After Get: " + cities.Count);

            foreach (CityTbl city in cities)
                await Console.Out.WriteLineAsync(city.CityName);

            int cityId = cities.Last().Id;
            await apiservice.DeleteACity(cityId);

            cities = await apiservice.GetAllCities();
            Console.WriteLine("After Delete: " + cities.Count);

            CityTbl c1 = new CityTbl() { CityName = "Natania" };
            await apiservice.InsertACity(c1);

            cities = await apiservice.GetAllCities();
            Console.WriteLine("After Insert: " + cities.Count);

            CityTbl myCity = cities.First();
            myCity.CityName = "Eilat";
            await apiservice.UpdateACity(myCity);

            cities = await apiservice.GetAllCities();
            Console.WriteLine("After Update: " + cities.Count);


            // DISEASES OR ISSUES
            Console.WriteLine("\n===== DISEASES OR ISSUES =====");

            DiseaseOrIssuesTblList doiList = await apiservice.GetAllDiseaseOrIssues();
            Console.WriteLine("After Get: " + doiList.Count);

            foreach (DiseaseOrIssuesTbl doi in doiList)
                await Console.Out.WriteLineAsync(doi.Disease);

            int doiId = doiList.Last().Id;
            await apiservice.DeleteADiseaseOrIssues(doiId);

            doiList = await apiservice.GetAllDiseaseOrIssues();
            Console.WriteLine("After Delete: " + doiList.Count);

            DiseaseOrIssuesTbl myD = new DiseaseOrIssuesTbl() { Disease = "fracture" };
            await apiservice.InsertADiseaseOrIssues(myD);

            doiList = await apiservice.GetAllDiseaseOrIssues();
            Console.WriteLine("After Insert: " + doiList.Count);

            DiseaseOrIssuesTbl doiUpdate = doiList.First();
            doiUpdate.Disease += "vv";
            await apiservice.UpdateADiseaseOrIssues(doiUpdate);

            doiList = await apiservice.GetAllDiseaseOrIssues();
            Console.WriteLine("After Update: " + doiList.Count);


            // ANIMAL TYPES
            Console.WriteLine("\n===== ANIMAL TYPES =====");

            AnimalTypeTblList atList = await apiservice.GetAllAnimalTypes();
            Console.WriteLine("After Get: " + atList.Count);

            foreach (AnimalTypeTbl at in atList)
                await Console.Out.WriteLineAsync(at.Type);

            int atId = atList.Last().Id;
            await apiservice.DeleteAnAnimalType(atId);

            atList = await apiservice.GetAllAnimalTypes();
            Console.WriteLine("After Delete: " + atList.Count);

            AnimalTypeTbl myAni = new AnimalTypeTbl() { Type = "snake" };
            await apiservice.InsertAnAnimalType(myAni);

            atList = await apiservice.GetAllAnimalTypes();
            Console.WriteLine("After Insert: " + atList.Count);

            AnimalTypeTbl atUpdate = atList.First();
            atUpdate.Type += "vv";
            await apiservice.UpdateAnAnimalType(atUpdate);

            atList = await apiservice.GetAllAnimalTypes();
            Console.WriteLine("After Update: " + atList.Count);


            // PERSONS
            Console.WriteLine("\n===== PERSONS =====");

            PersonTblList pList = await apiservice.GetAllPersons();
            Console.WriteLine("After Get: " + pList.Count);

            foreach (PersonTbl p in pList)
            {
                await Console.Out.WriteLineAsync(p.FirstName);
                await Console.Out.WriteLineAsync(p.City.CityName);
            }

            int personId = pList.Last().Id;
            await apiservice.DeleteAPerson(personId);

            pList = await apiservice.GetAllPersons();
            Console.WriteLine("After Delete: " + pList.Count);

            PersonTbl myp = new PersonTbl()
            {
                FirstName = "Hadas",
                FamilyName = "Drori",
                Tel = "053829666",
                City = cities[0],
                Email = "hadas@gmail.com",
                IsActive = true
            };
            await apiservice.InsertAPerson(myp);

            pList = await apiservice.GetAllPersons();
            Console.WriteLine("After Insert: " + pList.Count);

            PersonTbl pUpdate = pList.First();
            pUpdate.FirstName += "vv";
            await apiservice.UpdateAPerson(pUpdate);

            pList = await apiservice.GetAllPersons();
            Console.WriteLine("After Update: " + pList.Count);


            // AI
            Console.WriteLine("\n===== AI =====");

            AiTblList aiList = await apiservice.GetAllAi();
            Console.WriteLine("After Get: " + aiList.Count);

            foreach (AiTbl ai in aiList)
                await Console.Out.WriteLineAsync(ai.Message);

            int aiId = aiList.Last().Id;
            await apiservice.DeleteAnAi(aiId);

            aiList = await apiservice.GetAllAi();
            Console.WriteLine("After Delete: " + aiList.Count);

            AiTbl mya = new AiTbl()
            {
                IdPerson = pList[0],
                PromptTime = new DateTime(2026, 1, 12),
                Message = "My message",
                Response = "My response"
            };
            await apiservice.InsertAnAi(mya);

            aiList = await apiservice.GetAllAi();
            Console.WriteLine("After Insert: " + aiList.Count);

            AiTbl aiUpdate = aiList.First();
            aiUpdate.Message += "vv";
            await apiservice.UpdateAnAi(aiUpdate);

            aiList = await apiservice.GetAllAi();
            Console.WriteLine("After Update: " + aiList.Count);


            // ANIMALS
            Console.WriteLine("\n===== ANIMALS =====");

            AnimalTblList aList = await apiservice.GetAllAnimals();
            Console.WriteLine("After Get: " + aList.Count);

            foreach (AnimalTbl a in aList)
                await Console.Out.WriteLineAsync(a.BirthDate.ToString());

            int animalId = aList.Last().Id;
            await apiservice.DeleteAnAnimal(animalId);

            aList = await apiservice.GetAllAnimals();
            Console.WriteLine("After Delete: " + aList.Count);

            AnimalTbl myan = new AnimalTbl()
            {
                AnimalType = atList[1],
                BirthDate = new DateTime(2025, 1, 1)
            };
            await apiservice.InsertAnAnimal(myan);

            aList = await apiservice.GetAllAnimals();
            Console.WriteLine("After Insert: " + aList.Count);

            AnimalTbl aUpdate = aList.First();
            aUpdate.BirthDate = new DateTime(2003, 3, 3);
            await apiservice.UpdateAnAnimal(aUpdate);

            aList = await apiservice.GetAllAnimals();
            Console.WriteLine("After Update: " + aList.Count);


            // DOCTORS
            Console.WriteLine("\n===== DOCTORS =====");

            DoctorTblList dList = await apiservice.GetAllDoctors();
            Console.WriteLine("After Get: " + dList.Count);

            foreach (DoctorTbl d in dList)
                await Console.Out.WriteLineAsync(d.FamilyName);

            int doctorId = dList.Last().Id;
            await apiservice.DeleteADoctor(doctorId);

            dList = await apiservice.GetAllDoctors();
            Console.WriteLine("After Delete: " + dList.Count);

            DoctorTbl mydoc = new DoctorTbl()
            {
                FirstName = "p.FirstName",
                FamilyName = "p.FamilyName",
                Tel = "p.Tel",
                City = cities[0],
                Email = "p.Email"
            };
            await apiservice.InsertADoctor(mydoc);

            dList = await apiservice.GetAllDoctors();
            Console.WriteLine("After Insert: " + dList.Count);

            DoctorTbl dUpdate = dList.First();
            dUpdate.FamilyName += "vv";
            await apiservice.UpdateADoctor(dUpdate);

            dList = await apiservice.GetAllDoctors();
            Console.WriteLine("After Update: " + dList.Count);


            // OWNERS
            Console.WriteLine("\n===== OWNERS =====");

            OwnerTblList oList = await apiservice.GetAllOwners();
            Console.WriteLine("After Get: " + oList.Count);

            foreach (OwnerTbl o in oList)
                await Console.Out.WriteLineAsync(o.FamilyName + " " + o.City.CityName);

            int ownerId = oList.Last().Id;
            await apiservice.DeleteAnOwner(ownerId);

            oList = await apiservice.GetAllOwners();
            Console.WriteLine("After Delete: " + oList.Count);

            OwnerTbl myo = new OwnerTbl()
            {
                FirstName = "Elodi",
                FamilyName = "Maeev",
                Tel = "074918304",
                City = cities[1],
                Email = "e123@gmail.com",
                IsActive = true
            };
            await apiservice.InsertAnOwner(myo);

            oList = await apiservice.GetAllOwners();
            Console.WriteLine("After Insert: " + oList.Count);

            OwnerTbl oUpdate = oList.First();
            oUpdate.FamilyName += "vv";
            await apiservice.UpdateAnOwner(oUpdate);

            oList = await apiservice.GetAllOwners();
            Console.WriteLine("After Update: " + oList.Count);


            // REVIEWS
            Console.WriteLine("\n===== REVIEWS =====");

            ReviewTblList rList = await apiservice.GetAllReviews();
            Console.WriteLine("After Get: " + rList.Count);

            foreach (ReviewTbl r in rList)
                await Console.Out.WriteLineAsync(r.Description);

            int reviewId = rList.Last().Id;
            await apiservice.DeleteAReview(reviewId);

            rList = await apiservice.GetAllReviews();
            Console.WriteLine("After Delete: " + rList.Count);

            ReviewTbl myR = new ReviewTbl()
            {
                IdOwner = oList[0],
                Description = "yippie",
                Stars = 5,
                DateOfComment = new DateTime(2025, 1, 1)
            };
            await apiservice.InsertAReview(myR);

            rList = await apiservice.GetAllReviews();
            Console.WriteLine("After Insert: " + rList.Count);

            ReviewTbl rUpdate = rList.First();
            rUpdate.Description += "vv";
            await apiservice.UpdateAReview(rUpdate);

            rList = await apiservice.GetAllReviews();
            Console.WriteLine("After Update: " + rList.Count);


            // OWNERS ANIMALS
            Console.WriteLine("\n===== OWNERS ANIMALS =====");

            OwnersAnimalTblList oaList = await apiservice.GetAllOwnersAnimals();
            Console.WriteLine("After Get: " + oaList.Count);

            foreach (OwnersAnimalTbl oa in oaList)
                await Console.Out.WriteLineAsync(oa.Animal.Id.ToString());

            int oaId = oaList.Last().Id;
            await apiservice.DeleteAnOwnersAnimal(oaId);

            oaList = await apiservice.GetAllOwnersAnimals();
            Console.WriteLine("After Delete: " + oaList.Count);

            OwnersAnimalTbl myoa = new OwnersAnimalTbl()
            {
                Owner = oList[1],
                Animal = aList[1]
            };
            await apiservice.InsertAnOwnersAnimal(myoa);

            oaList = await apiservice.GetAllOwnersAnimals();
            Console.WriteLine("After Insert: " + oaList.Count);

            OwnersAnimalTbl oaUpdate = oaList.First();
            oaUpdate.Animal.Id = 2;
            await apiservice.UpdateAnOwnersAnimal(oaUpdate);

            oaList = await apiservice.GetAllOwnersAnimals();
            Console.WriteLine("After Update: " + oaList.Count);


            // QUEUES
            Console.WriteLine("\n===== QUEUES =====");

            QueueTblList qList = await apiservice.GetAllQueues();
            Console.WriteLine("After Get: " + qList.Count);

            foreach (QueueTbl q in qList)
                await Console.Out.WriteLineAsync(q.IssueOrDisease.Id.ToString());

            int queueId = qList.Last().Id;
            await apiservice.DeleteAQueue(queueId);

            qList = await apiservice.GetAllQueues();
            Console.WriteLine("After Delete: " + qList.Count);

            QueueTbl myQueue = new QueueTbl()
            {
                IdDoctor = dList[0],
                IdOwnersAnimal = oaList[0],
                IssueOrDisease = doiList[0],
                QueueDate = new DateTime(2026, 7, 7),
                QueueHour = "10:30",
                Report = "all is well"
            };
            await apiservice.InsertAQueue(myQueue);

            qList = await apiservice.GetAllQueues();
            Console.WriteLine("After Insert: " + qList.Count);

            QueueTbl qUpdate = qList.First();
            qUpdate.Report += "vv";
            await apiservice.UpdateAQueue(qUpdate);

            qList = await apiservice.GetAllQueues();
            Console.WriteLine("After Update: " + qList.Count);


            // SHIFTS
            Console.WriteLine("\n===== SHIFTS =====");

            ShiftsTblList sList = await apiservice.GetAllShifts();
            Console.WriteLine("After Get: " + sList.Count);

            foreach (ShiftsTbl s in sList)
                await Console.Out.WriteLineAsync(s.IdDoctor.Id.ToString());

            int shiftId = sList.Last().Id;
            await apiservice.DeleteAShift(shiftId);

            sList = await apiservice.GetAllShifts();
            Console.WriteLine("After Delete: " + sList.Count);

            ShiftsTbl myShift = new ShiftsTbl()
            {
                IdDoctor = dList[1],
                ShiftDate = new DateTime(2024, 4, 4),
                StartTime = "08:00",
                EndTime = "16:00"
            };
            await apiservice.InsertAShift(myShift);

            sList = await apiservice.GetAllShifts();
            Console.WriteLine("After Insert: " + sList.Count);

            ShiftsTbl sUpdate = sList.First();
            sUpdate.IdDoctor = dList[2];
            await apiservice.UpdateAShift(sUpdate);

            sList = await apiservice.GetAllShifts();
            Console.WriteLine("After Update: " + sList.Count);
        }
    }
}
