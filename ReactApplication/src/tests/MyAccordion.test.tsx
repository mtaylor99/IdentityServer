import {describe, expect, test} from 'vitest';
import {render, screen} from '@testing-library/react';
import MyAccordion from './MyAccordion';

describe("Accordion test", () => {
    test("should show title all the time", () => {
        
        render(<MyAccordion title='Testing'><h4>Content</h4></MyAccordion>);

        expect(screen.getByText(/Testing/i)).toBeDefined()
    })
})