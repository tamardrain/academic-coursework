const express = require('express')
const cors = require('cors')
const app = express()
const PORT = 8080

app.use(express.json()) // Converts incoming body data to JSON
app.use(cors()) // Enables cross-origin resource sharing for websites

const Users = [
    { id: 1, password: "1234", email: "t@gmail", phon: "0504170727", role: 2 },
    { id: 2, password: "1456", email: "m@gmail", phon: "055214027", role: 2 },
    { id: 3, password: "12256", email: "l@gmail", phon: "0500254124", role: 2 },
    { id: 4, password: "124444", email: "d@gmail", phon: "0545678927", role: 2 },
    { id: 5, password: "17894", email: "k@gmail", phon: "0552369047", role: 2 },
]

const Buses = [
    { id: 1, number: 59, from: "neve yaakov", to: "givat shaul" },
    { id: 2, number: 65, from: "ramot", to: "harhotzvim" },
    { id: 3, number: 45, from: "ramot shlomo", to: "geula" },
    { id: 4, number: 18, from: "ramat shlomo", to: "ramot" },
    { id: 5, number: 39, from: "bait vagan", to: "geula" },
    { id: 6, number: 69, from: "givat shaul", to: "neve yaakov" },
    { id: 7, number: 89, from: "harhotzvim", to: "geula" },
    { id: 8, number: 33, from: "herzel", to: "gilo" },
]

const Complaints = [
    { id: 1, busId: 2, userId: 2, stopNumber: 1254, Date: "2025", time: "17:00", desec: "the bus didnt arrive", empId: 1, empDesc: "", completed: false },
    { id: 2, busId: 3, userId: 3, stopNumber: 1784, Date: "2024", time: "18:00", desec: "the bus didnt arrive", empId: 2, empDesc: "", completed: false },
    { id: 3, busId: 1, userId: 4, stopNumber: 12451, Date: "2023", time: "19:00", desec: "the bus didnt arrive", empId: 3, empDesc: "", completed: false },
    { id: 4, busId: 2, userId: 5, stopNumber: 1987, Date: "2021", time: "14:00", desec: "the bus didnt arrive", empId: 4, empDesc: "", completed: false },
    { id: 5, busId: 2, userId: 1, stopNumber: 1254, Date: "2025", time: "17:00", desec: "the bus didnt arrive", empId: 5, empDesc: "", completed: false },
    { id: 6, busId: 6, userId: 3, stopNumber: 1784, Date: "2024", time: "18:00", desec: "the bus didnt arrive", empId: 2, empDesc: "", completed: false },
    { id: 7, busId: 8, userId: 4, stopNumber: 12451, Date: "2023", time: "19:00", desec: "the bus didnt arrive", empId: 3, empDesc: "", completed: false },
    { id: 8, busId: 6, userId: 5, stopNumber: 1987, Date: "2021", time: "14:00", desec: "the bus didnt arrive", empId: 5, empDesc: "", completed: false },
    { id: 9, busId: 1, userId: 2, stopNumber: 1254, Date: "2025", time: "17:00", desec: "the bus didnt arrive", empId: 1, empDesc: "", completed: false },
    { id: 10, busId: 3, userId: 1, stopNumber: 1784, Date: "2024", time: "18:00", desec: "the bus didnt arrive", empId: 4, empDesc: "", completed: false },
    { id: 11, busId: 1, userId: 4, stopNumber: 12451, Date: "2023", time: "19:00", desec: "the bus didnt arrive", empId: 3, empDesc: "", completed: false },
    { id: 12, busId: 2, userId: 1, stopNumber: 1987, Date: "2021", time: "14:00", desec: "the bus didnt arrive", empId: 3, empDesc: "", completed: false },
]

// Retrieve all users
app.get("/getAllUsers", (req, res) => {
    res.send(Users);
})

// Add a new user
app.post("/addUser", (req, res) => {
    const newUser = req.body
    console.log("our body is: ", newUser);

    newUser.id = Users[Users.length - 1].id + 1;
    Users.push(newUser)
    res.send({ inserted: newUser.id, massage: "success" })
})

// Retrieve an existing user by email and password
app.get("/login", (req, res) => {
    const { email, password } = req.body;
    const user = Users.find(x => x.email == email && x.password == password)
    res.send({ message: "success", user: user })
})

// Update user details
app.put("/updateUser/:id", (req, res) => {
    const updateUser = req.body
    const userID = Number(req.params.id)
    const index = Users.findIndex(x => x.id == userID)
    Users[index].email = updateUser.email
    Users[index].password = updateUser.password
    res.send({ massage: "success" })
})

// Retrieve a list of complaints within a date range
app.get("/getAllComplaints", (req, res) => {
    const startDate = req.query.startDate || "2020"
    const endDate = req.query.endDate || "2024"
    const filterComplaints = Complaints.filter(c => c.Date >= startDate && c.Date <= endDate);
    res.send(filterComplaints);
})

// Retrieve a list of complaints by user ID
app.get("/getAllComplaintsByUserId/:userId", (req, res) => {
    const id = Number(req.params.userId);
    const isCompleted = req.query.completed;
  
    let ComplaintsByUserId;
    // If the client did not request only completed complaints
    if (!isCompleted || isCompleted === "false") {
        ComplaintsByUserId = Complaints.filter(c => c.userId === id);
    }
    else {
        ComplaintsByUserId = Complaints.filter(c => c.userId === id && c.completed === true);  
    }
    res.send(ComplaintsByUserId);
})

// Retrieve a list of complaints by company employee ID
app.get("/getAllComplaintsByEmpId/:empId", (req, res) => {
    const empId = Number(req.params.empId);
    const ComplaintsByEmpId = Complaints.filter(c => c.empId === empId);
    res.send(ComplaintsByEmpId);
})

app.listen(PORT, () => {
    console.log(`Example app listening on port ${PORT}`)
})

// Retrieve a single complaint by complaint ID
app.get("/getComplaintById/:id", (req, res) => {
    const id = Number(req.params.id);
    const ComplaintById = Complaints.filter(c => c.id === id);
    res.send(ComplaintById);
})

// Add a new complaint
app.post("/addComplaint", (req, res) => {
    const newComplaint = req.body;
    newComplaint.id = Complaints[Complaints.length - 1].id + 1;
    Complaints.push(newComplaint);
    res.send({ inserted: newComplaint.id, massage: "success" });
})

// Update a complaint
app.put("/updateComplaint/:id", (req, res) => {
    const id = Number(req.params.id);
    const updateComplaint = req.body;
    const index = Complaints.findIndex(c => c.id === id);
    Complaints[index].completed = updateComplaint.completed;
    Complaints[index].empDesc = updateComplaint.empDesc;
    res.send({ massage: "success" })
})

// Retrieve the top 5 bus lines with the highest number of complaints
app.get("/get5WorstBuses", (req, res) => {
  // Count complaints for each busId
  const counts = {};
  for (let i = 0; i < Complaints.length; i++) {
    const busId = Complaints[i].busId;
    if (!counts[busId]) counts[busId] = 0;
    counts[busId]++;
  }

  // Create an array of buses with their complaint counts
  const busesWithCounts = [];
  for (let i = 0; i < Buses.length; i++) {
    const bus = Buses[i];
    busesWithCounts.push({
      bus: bus,
      complaintsCount: counts[bus.id] || 0
    });
  }

  // Sort by number of complaints in descending order
  busesWithCounts.sort((a, b) => b.complaintsCount - a.complaintsCount);

  // Return the top 5
  const bestBuses = busesWithCounts.slice(0, 5);
  res.send(bestBuses);
})

// Retrieve bus lines that have no complaints at all
app.get("/getBestBuses", (req, res) => {
  const counts = {};
  for (let i = 0; i < Complaints.length; i++) {
    const busId = Complaints[i].busId;
    if (!counts[busId]) counts[busId] = 0;
    counts[busId]++;
  }

  const busesWithoutComplaints = [];
  for (let i = 0; i < Buses.length; i++) {
    if (!counts[Buses[i].id]) {
      busesWithoutComplaints.push(Buses[i]);
    }
  }

  res.send(busesWithoutComplaints);
})

// Retrieve a list of employees based on the number of complaints handled by each employee
app.get("/getAllEmps", (req, res) => {
  const empMap = {};

  for (let i = 0; i < Complaints.length; i++) {
    const complaint = Complaints[i];
    const empId = complaint.empId;

    // If the employee does not exist in the map, create them
    if (!empMap[empId]) {
      empMap[empId] = {
        empId: empId,
        complaintsHandled: 0
      };
    }

    // Count only completed complaints
    if (complaint.completed) {
      empMap[empId].complaintsHandled++;
    }
  }

  // Convert the object into an array
  const result = [];
  for (let key in empMap) {
    result.push(empMap[key]);
  }

  res.send(result);
})