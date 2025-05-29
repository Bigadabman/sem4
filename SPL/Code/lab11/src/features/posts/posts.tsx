import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks';
import { loadPosts, selectPosts } from './postsSlice';
import PostItem from '../../components/PostItem';
import {PostForm} from '../../components/PostForm';

export function  Posts() {
  const dispatch = useAppDispatch();
  const posts = useAppSelector(selectPosts);

  useEffect(() => {
    dispatch(loadPosts());
  }, [dispatch]);

  return (
    <div className="posts-container">
      <h1>Posts Manager</h1>
      <PostForm />
      {posts.map((post, index) => (
        <PostItem key={post.id} post={post} index={index} />
      ))}
    </div>
  );
};

export default Posts;
