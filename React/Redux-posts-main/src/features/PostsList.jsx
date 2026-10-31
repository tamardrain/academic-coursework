import React from 'react'
import { useSelector } from 'react-redux'
import AddPost from './AddPost'
import PostCard from './PostCard'

const PostsList = () => {
  const posts=useSelector(state=>state.posts.posts)
  return (
    <div>
        <h1>הפוסטים של משפחת דריין</h1>
        {posts.map(t =><PostCard key={t.id} id={t.id} title={t.title} content={t.content}/>)}
        <AddPost />
    </div>
  )
}

export default PostsList