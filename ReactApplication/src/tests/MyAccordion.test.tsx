import {describe, expect, test} from 'vitest';
import {render, screen, waitFor} from '@testing-library/react';
import MyAccordion from './MyAccordion';

describe("Accordion test", () => {
    test("should show title all the time", () => {
        
        render(<MyAccordion title='Testing'><h4>Content</h4></MyAccordion>);

        expect(screen.getByText(/Testing/i)).toBeDefined()
    })

    test("Snapshot - Accordion component", async () => {
        const { container, getByText } = render(<MyAccordion title='Testing'><h4>Content</h4></MyAccordion>);
    
        await waitFor(() => getByText(/Testing/i));
    
        expect(container).toMatchSnapshot();
      });

})