import React, { useState } from 'react';
import { Post } from '../features/posts/postsAPI';
import { useAppDispatch } from '../hooks';
import { editPost, removePost, editLocalPost } from '../features/posts/postsSlice';

interface Props { post: Post; index: number; }

export function PostItem({ post, index }: Props){
  const dispatch = useAppDispatch();
  const [isEditing, setIsEditing] = useState(false);
  const [title, setTitle] = useState(post.title);
  const [body, setBody] = useState(post.body);

  // Обновляем состояние при изменении пропсов post
  React.useEffect(() => {
    setTitle(post.title);
    setBody(post.body);
  }, [post.title, post.body]);

  const onSave = () => {
const updatedPost = { ...post, title, body };

  if (post.id > 100) {
    dispatch(editLocalPost(updatedPost)); 
  } else {
    dispatch(editPost(updatedPost)); 
  }

  setIsEditing(false);
  };

  return (
    <div
      className="post-item"
      style={{ '--post-index': index } as React.CSSProperties}
    >
      {isEditing ? (
        <>
          <input value={title} onChange={e => setTitle(e.target.value)} />
          <textarea value={body} onChange={e => setBody(e.target.value)} />
          <button onClick={onSave}>Save</button>
        </>
      ) : (
        <>
          <h2>{post.title}</h2>
          <p>{post.body}</p>
          <button onClick={() => setIsEditing(true)}>Edit</button>
          <button onClick={() => dispatch(removePost(post.id))}>Delete</button>
        </>
      )}
    </div>
  );
};

export default PostItem;