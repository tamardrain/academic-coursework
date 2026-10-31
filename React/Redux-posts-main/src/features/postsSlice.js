import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  //   posts: [
  //   {
  //     id: 1,
  //     title: 'פוסט 1',
  //     content: 'מה שלומכם היום?',
  //   },
  //   {
  //     id: 2,
  //     title: 'פוסט 2',
  //     content: 'יצאתי לעבודה בשעה 10 בבוקר',
  //   },
  //   {
  //     id: 3,
  //     title: 'פוסט 3',
  //     content: 'המפגש של המשפחה יתקיים ביום שני הבא- מי יכול לבוא?',
  //   },
  //   {
  //     id: 4,
  //     title: 'פוסט 4',
  //     content: 'יש לנו מסיבה בגן של הילדה ביום שני',
  //   },
  // ],
  posts:[],
}

export const postsSlice = createSlice({
  name: 'counter',
  initialState,
  reducers: {
    postsFetched:(state,action)=>{
      state.posts=action.payload
    },
    addToPostList:(state,action)=>{
        const newPost=action.payload;
        newPost.id=state.posts[state.posts.length-1].id+1;
        state.posts.push(newPost);
    },
    deletePost:(state,action)=>{
        const postId=action.payload
       state.posts= state.posts.filter(p => p.id != postId);
    }

  
  },
})

// Action creators are generated for each case reducer function
export const { addToPostList,deletePost,postsFetched } = postsSlice.actions

export default postsSlice.reducer