import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { useDispatch, useSelector } from 'react-redux';
import {usersFetched } from './features/users/usersSlice';

function App() {
//להחליף ניתוב לשרת שיצרתי כבר בכיתה
//בדף שרת להתקין קורס ולהוסיף את המידלוויר
//app.use(cors())
const dispatch=useDispatch();
const users=useSelector((state)=>state.users.users);
  useEffect(()=>{
    axios.get("https://jsonplaceholder.typicode.com/users").then(res=>{
      console.log(res.data);
      const users=res.data;
      dispatch(usersFetched(users));
    })
  },[])

const [name,setName]=useState("");
const [email,setEmail]=useState("");
const [password,setPassword]=useState("");

const addUserClicked=()=>{
  //הוספת משתמש 
}

  return (
    <div className="App">
     {users.map((u)=> <ul>
      <li>userId: {u.id}</li>
      <li>name: {u.name}</li>
      <li>email: {u.email}</li>
       
      </ul>)}
      <form>
        <input type="text" placeholder='הכנס שם' value={name}onChange={(n)=>{setName(n.target.value)}}/>
        <input type="text" placeholder='הכנס אימייל' value={email} onChange={(e)=>{setEmail(e.target.value)}}/>
        <input type="text" placeholder='הכנס סיסמה' value={password} onChange={(p)=>{setPassword(p.target.value)}}/>
        {/* <button type='button'onClick={()=>{addUserClicked()}}>הרשם</button> */}
      </form>
      
    </div>
  );
}

export default App;
