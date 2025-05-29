import { createSlice, createAsyncThunk, createAction } from '@reduxjs/toolkit';
import { fetchPosts, createPost, updatePost, deletePost, Post, NewPost } from './postsAPI';
import { RootState } from '../../app/store';

interface PostsState {
  items: Post[];
  loading: boolean;
  error: string | null;
}

const initialState: PostsState = {
  items: [],
  loading: false,
  error: null,
};

// Получение списка постов
export const loadPosts = createAsyncThunk<Post[]>('posts/load', fetchPosts);
// Добавление нового поста
export const addNewPost = createAsyncThunk<Post, NewPost>('posts/add', createPost);
// Редактирование поста
export const editPost = createAsyncThunk<Post, Post>('posts/edit', updatePost);
// Удаление поста
export const removePost = createAsyncThunk<number, number>('posts/remove', async (id) => {
  await deletePost(id);
  return id;
});

export const editLocalPost = createAction<Post>('posts/editLocal');

const postsSlice = createSlice({
  name: 'posts',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      // loadPosts
      .addCase(loadPosts.pending, (state) => { state.loading = true; })
      .addCase(loadPosts.fulfilled, (state, action) => {
        state.items = action.payload;
        state.loading = false;
      })
      .addCase(loadPosts.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to load posts';
      })
      // addNewPost
      .addCase(addNewPost.fulfilled, (state, action) => {
        const maxId = state.items.reduce((max, p) => Math.max(max, p.id), 0);
        const newPost: Post = { ...action.payload, id: maxId + 1 };
        state.items.unshift(newPost);
      })
      // editPost
      .addCase(editPost.fulfilled, (state, action) => {
        const index = state.items.findIndex(p => p.id === action.payload.id);
        if (index !== -1) {
          state.items[index] = action.payload;
        }
      })
      // removePost
      .addCase(removePost.fulfilled, (state, action) => {
        state.items = state.items.filter(p => p.id !== action.payload);
      })
      .addCase(editLocalPost, (state, action) => {
  const index = state.items.findIndex(p => p.id === action.payload.id);
  if (index !== -1) {
    state.items[index] = action.payload;
  }
})
;
  },
});

export const selectPosts = (state: RootState) => state.posts.items;
export default postsSlice.reducer;