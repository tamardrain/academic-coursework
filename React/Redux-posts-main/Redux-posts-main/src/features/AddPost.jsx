import React, { useState } from 'react'
import { useDispatch } from 'react-redux';
import {addToPostList} from './postsSlice'
const AddPost = () => {

    const [aPost, setaPost] = useState("");
    const dispatch = useDispatch();
    const addedPostClicked = () => {
        const newPost = {
            id: 0,
            title: 'פוסט ',
            content: aPost,
        };
        dispatch(addToPostList(newPost));
setaPost("");
    }
    return (
        <div>
            <input type='text' placeholder=' הוסף פוסט....' value={aPost} onChange={(e) => { setaPost(e.target.value) }} />
            <button type='button' onClick={addedPostClicked}>הוסף</button>
        </div>
    )
}

export default AddPost