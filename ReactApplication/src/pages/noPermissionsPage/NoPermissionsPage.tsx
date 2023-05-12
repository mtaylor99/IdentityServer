import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { Box, Paper, Typography } from '@mui/material';

export function NoPermissionsPage() {
  return (
    <Box
      sx={{
        display: 'flex',
        height: '80vh',
        width: '100%',
        justifyContent: 'center',
        alignItems: 'center',
        background: '#F5F7F8',
      }}
    >
      <Paper
        sx={{
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          alignItems: 'center',
          p: '2rem',
          borderRadius: '10px',
        }}
      >
        <ErrorOutlineIcon fontSize="large" />
        <Typography variant="h3" sx={{ p: '2rem' }}>
          You do not have the permission to view this content
        </Typography>
      </Paper>
    </Box>
  );
}
