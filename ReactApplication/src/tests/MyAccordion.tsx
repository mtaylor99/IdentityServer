import { Box, useTheme } from '@mui/material';
import React from 'react';

type AccordionProps = {
  title: string;
  children: React.ReactNode;
};
const MyAccordion = (props: AccordionProps) => {
  const theme = useTheme();
  const { title, children } = props;

  return (
    <Box
      sx={{
        color: theme.palette.primary.light,
        '&:hover': {
          backgroundColor: 'primary.main',
          opacity: [0.9, 0.8, 0.7],
        },
      }}
    >
      <h3 className="accordion-title">{title}</h3>
      <div className="accordion-content">{children}</div>
    </Box>
  );
};

export default MyAccordion;
