import { Link } from 'react-router-dom';

export default function Page404() {
  return (
    <div style={{
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      justifyContent: 'center',
      minHeight: '100vh',
      textAlign: 'center',
      padding: '2rem'
    }}>
      <h1 style={{ fontSize: '4rem', marginBottom: '1rem' }}>404</h1>
      <p style={{ fontSize: '1.2rem', marginBottom: '2rem', color: '#666' }}>
        Page not found
      </p>
      <Link 
        to="/"
        style={{
          textDecoration: 'none',
          color: '#2196F3',
          border: '1px solid #2196F3',
          padding: '0.5rem 1rem',
          borderRadius: '4px',
          transition: 'all 0.3s ease'
        }}
        onMouseOver={e => {
          (e.currentTarget.style.backgroundColor = '#2196F3');
          (e.currentTarget.style.color = 'white');
        }}
        onMouseOut={e => {
          (e.currentTarget.style.backgroundColor = 'transparent');
          (e.currentTarget.style.color = '#2196F3');
        }}
      >
        Return to Sign In
      </Link>
    </div>
  );
}