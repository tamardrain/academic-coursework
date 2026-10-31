
import { useEffect } from 'react';
import './App.css';
import PostsList from './features/PostsList.jsx';
import axios from 'axios';
import { useDispatch } from 'react-redux';
import { postsFetched } from './features/postsSlice.js';




function App() {
  const dispatch=useDispatch();
//מה שבתוך ההוק הזה קורה פעם אחת בלבד כשהקומפוננטה נטענת לראשונה
 useEffect(()=>{
  axios.get("https://jsonplaceholder.typicode.com/posts?userId=3").then(res=>{
    const posts=res.data;
    // (console.log(posts));
    dispatch(postsFetched(posts));
    
       }).catch(err=>{
            console.log(err);
            alert("server error");   
        })
        
    }, [])


  //על מנת שנוכל לראות תצוגה בדפדפן
//  יש להביא כאן את הקומפוננטה בצורה של תגית עם שם הקומפוננטה
  return (
    <div className="App">
      {
       <PostsList />
      }
   
    </div>
  );
}

export default App;
