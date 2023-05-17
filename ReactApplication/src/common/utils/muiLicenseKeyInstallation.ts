import { LicenseInfo } from '@mui/x-license-pro';

export const installMuiLicense = () => {
  const key = import.meta.env.VITE_APP_MUI_LICENSE_KEY;

  if (!key) {
    console.error(
      `Could not retrieve MUI licese from config. The key within the config is called: VITE_APP_MUI_LICENSE_KEY`
    );
    return;
  }

  LicenseInfo.setLicenseKey(key);
};
