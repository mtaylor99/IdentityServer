import { useState } from 'react';

export interface IUseModalState<T> {
  isShowing: boolean;
  modalData: T | null;
  showModal: (newData?: T) => void;
  hideModal: () => void;
}

export function useModalState<TModalData>({
  initialModalState = false,
  modalStateData = null,
} = {}): IUseModalState<TModalData> {
  const [isShowing, setIsShowing] = useState<boolean>(initialModalState);
  const [modalData, setModalData] = useState<TModalData | null>(
    modalStateData ?? null
  );

  const showModal = (newData?: TModalData) => {
    setIsShowing(true);
    setModalData(newData ?? null);
  };

  const hideModal = () => {
    setIsShowing(false);
    setModalData(null);
  };

  return { isShowing, modalData, showModal, hideModal };
}
