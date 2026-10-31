import React from 'react'
import { useDispatch } from 'react-redux'
import {deletePost} from './postsSlice'

const PostCard = ({id,title,content}) => {
const dispatch=useDispatch();
const deletedClicked=()=>{
dispatch(deletePost(id));
}

  return (
    <div>
        {/* <h1>פוסט</h1> */}
        {/* <p>id{id}</p> */}
        <p>title: {title}</p>
        {/* <p>content{content}</p> */}
        <button type='button' onClick={()=>{deletedClicked()}}>הסר</button>
    </div>
  )
}

export default PostCard