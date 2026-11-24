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
            CityTblList cities = await apiservice.GetAllCities();
            foreach (CityTbl city in cities)
                await Console.Out.WriteLineAsync(city.CityName);

            Console.WriteLine(cities.Count);
            int cityId = cities.Last().Id;
            await apiservice.DeleteACity(cityId);
            cities = await apiservice.GetAllCities();
            Console.WriteLine(cities.Count);

            CityTbl c1 = new CityTbl() { CityName = "Natania" };
            await apiservice.InsertACity(c1);

            CityTbl myCity = cities.First();
            myCity.CityName = "Eilat";
            await apiservice.UpdateACity(myCity);


            // DISEASES OR ISSUES
            DiseaseOrIssuesTblList doiList = await apiservice.GetAllDiseaseOrIssues();
            foreach (DiseaseOrIssuesTbl doi in doiList)
                await Console.Out.WriteLineAsync(doi.Disease);

            Console.WriteLine(doiList.Count);
            int doiId = doiList.Last().Id;
            await apiservice.DeleteADiseaseOrIssues(doiId);
            doiList = await apiservice.GetAllDiseaseOrIssues();
            Console.WriteLine(doiList.Count);

            DiseaseOrIssuesTbl myD = new DiseaseOrIssuesTbl() { Disease = "fracture" };
            await apiservice.InsertADiseaseOrIssues(myD);

            DiseaseOrIssuesTbl doiUpdate = doiList.First();
            doiUpdate.Disease += "vv";
            await apiservice.UpdateADiseaseOrIssues(doiUpdate);


            // ANIMAL TYPES
            AnimalTypeTblList atList = await apiservice.GetAllAnimalTypes();
            foreach (AnimalTypeTbl at in atList)
                await Console.Out.WriteLineAsync(at.Type);

            Console.WriteLine(atList.Count);
            int atId = atList.Last().Id;
            await apiservice.DeleteAnAnimalType(atId);
            atList = await apiservice.GetAllAnimalTypes();
            Console.WriteLine(atList.Count);

            AnimalTypeTbl myAni = new AnimalTypeTbl() { Type = "snake" };
            await apiservice.InsertAnAnimalType(myAni);

            AnimalTypeTbl atUpdate = atList.First();
            atUpdate.Type += "vv";
            await apiservice.UpdateAnAnimalType(atUpdate);


            // PERSONS
            PersonTblList pList = await apiservice.GetAllPersons();
            foreach (PersonTbl p in pList)
            {
                await Console.Out.WriteLineAsync(p.FirstName);
                await Console.Out.WriteLineAsync(p.City.CityName);
            }

            Console.WriteLine(pList.Count);
            int personId = pList.Last().Id;
            await apiservice.DeleteAPerson(personId);
            pList = await apiservice.GetAllPersons();
            Console.WriteLine(pList.Count);

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

            PersonTbl pUpdate = pList.First();
            pUpdate.FirstName += "vv";
            await apiservice.UpdateAPerson(pUpdate);


            // AI
            AiTblList aiList = await apiservice.GetAllAi();
            foreach (AiTbl ai in aiList)
                await Console.Out.WriteLineAsync(ai.Message);

            Console.WriteLine(aiList.Count);
            int aiId = aiList.Last().Id;
            await apiservice.DeleteAnAi(aiId);
            aiList = await apiservice.GetAllAi();
            Console.WriteLine(aiList.Count);

            AiTbl mya = new AiTbl()
            {
                IdPerson = pList[0],
                PromptTime = new DateTime(2026, 1, 12),
                Message = "My message",
                Response = "My response"
            };
            await apiservice.InsertAnAi(mya);

            AiTbl aiUpdate = aiList.First();
            aiUpdate.Message += "vv";
            await apiservice.UpdateAnAi(aiUpdate);


            // ANIMALS
            AnimalTblList aList = await apiservice.GetAllAnimals();
            foreach (AnimalTbl a in aList)
                await Console.Out.WriteLineAsync(a.BirthDate.ToString());

            Console.WriteLine(aList.Count);
            int animalId = aList.Last().Id;
            await apiservice.DeleteAnAnimal(animalId);
            aList = await apiservice.GetAllAnimals();
            Console.WriteLine(aList.Count);

            AnimalTbl myan = new AnimalTbl()
            {
                AnimalType = atList[1],
                BirthDate = new DateTime(2025, 1, 1)
            };
            await apiservice.InsertAnAnimal(myan);

            AnimalTbl aUpdate = aList.First();
            aUpdate.BirthDate = new DateTime(2003, 3, 3);
            await apiservice.UpdateAnAnimal(aUpdate);


            // DOCTORS
            DoctorTblList dList = await apiservice.GetAllDoctors();
            foreach (DoctorTbl d in dList)
                await Console.Out.WriteLineAsync(d.FamilyName);

            Console.WriteLine(dList.Count);
            int doctorId = dList.Last().Id;
            await apiservice.DeleteADoctor(doctorId);
            dList = await apiservice.GetAllDoctors();
            Console.WriteLine(dList.Count);

            DoctorTbl mydoc = new DoctorTbl()
            {
                FirstName = "p.FirstName",
                FamilyName = "p.FamilyName",
                Tel = "p.Tel",
                City = cities[0],
                Email = "p.Email"
            };
            await apiservice.InsertADoctor(mydoc);

            DoctorTbl dUpdate = dList.First();
            dUpdate.FamilyName += "vv";
            await apiservice.UpdateADoctor(dUpdate);


            // OWNERS
            OwnerTblList oList = await apiservice.GetAllOwners();
            foreach (OwnerTbl o in oList)
                await Console.Out.WriteLineAsync(o.FamilyName + " " + o.City.CityName);

            Console.WriteLine(oList.Count);
            int ownerId = oList.Last().Id;
            await apiservice.DeleteAnOwner(ownerId);
            oList = await apiservice.GetAllOwners();
            Console.WriteLine(oList.Count);

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

            OwnerTbl oUpdate = oList.First();
            oUpdate.FamilyName += "vv";
            await apiservice.UpdateAnOwner(oUpdate);


            // REVIEWS
            ReviewTblList rList = await apiservice.GetAllReviews();
            foreach (ReviewTbl r in rList)
                await Console.Out.WriteLineAsync(r.Description);

            Console.WriteLine(rList.Count);
            int reviewId = rList.Last().Id;
            await apiservice.DeleteAReview(reviewId);
            rList = await apiservice.GetAllReviews();
            Console.WriteLine(rList.Count);

            ReviewTbl myR = new ReviewTbl()
            {
                IdOwner = oList[0],
                Description = "yippie",
                Stars = 5,
                DateOfComment = new DateTime(2025, 1, 1)
            };
            await apiservice.InsertAReview(myR);

            ReviewTbl rUpdate = rList.First();
            rUpdate.Description += "vv";
            await apiservice.UpdateAReview(rUpdate);


            // OWNERS ANIMALS
            OwnersAnimalTblList oaList = await apiservice.GetAllOwnersAnimals();
            foreach (OwnersAnimalTbl oa in oaList)
                await Console.Out.WriteLineAsync(oa.Animal.Id.ToString());

            Console.WriteLine(oaList.Count);
            int oaId = oaList.Last().Id;
            await apiservice.DeleteAnOwnersAnimal(oaId);
            oaList = await apiservice.GetAllOwnersAnimals();
            Console.WriteLine(oaList.Count);

            OwnersAnimalTbl myoa = new OwnersAnimalTbl()
            {
                Owner = oList[1],
                Animal = aList[1]
            };
            await apiservice.InsertAnOwnersAnimal(myoa);

            OwnersAnimalTbl oaUpdate = oaList.First();
            oaUpdate.Animal.Id = 2;
            await apiservice.UpdateAnOwnersAnimal(oaUpdate);


            // QUEUES
            QueueTblList qList = await apiservice.GetAllQueues();
            foreach (QueueTbl q in qList)
                await Console.Out.WriteLineAsync(q.IssueOrDisease.Id.ToString());

            Console.WriteLine(qList.Count);
            int queueId = qList.Last().Id;
            await apiservice.DeleteAQueue(queueId);
            qList = await apiservice.GetAllQueues();
            Console.WriteLine(qList.Count);

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

            QueueTbl qUpdate = qList.First();
            qUpdate.Report += "vv";
            await apiservice.UpdateAQueue(qUpdate);


            // SHIFTS
            ShiftsTblList sList = await apiservice.GetAllShifts();
            foreach (ShiftsTbl s in sList)
                await Console.Out.WriteLineAsync(s.IdDoctor.Id.ToString());

            Console.WriteLine(sList.Count);
            int shiftId = sList.Last().Id;
            await apiservice.DeleteAShift(shiftId);
            sList = await apiservice.GetAllShifts();
            Console.WriteLine(sList.Count);

            ShiftsTbl myShift = new ShiftsTbl()
            {
                IdDoctor = dList[1],
                ShiftDate = new DateTime(2024, 4, 4),
                StartTime = "08:00",
                EndTime = "16:00"
            };
            await apiservice.InsertAShift(myShift);

            ShiftsTbl sUpdate = sList.First();
            sUpdate.IdDoctor = dList[2];
            await apiservice.UpdateAShift(sUpdate);

        }
    }
}
