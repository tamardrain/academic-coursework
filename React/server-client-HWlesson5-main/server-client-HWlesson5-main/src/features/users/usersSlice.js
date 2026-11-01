import { createSlice } from '@reduxjs/toolkit'

const initialState = {
 users:[],
}

export const usersSlice = createSlice({
  name: 'counter',
  initialState,
  reducers: {
    usersFetched:(state,action)=>{
        state.users=action.payload;
    },
    addUsers:(state,action)=>{
        const newUser=action.payload;
        state.users.push(newUser);

    }
   
  },
})

// Action creators are generated for each case reducer function
export const { usersFetched, addUsers } = usersSlice.actions

export default usersSlice.reducer