/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "cdn.millionluxury.com",
      },
      {
        protocol: "https",
        hostname: "maustorageprod.blob.core.windows.net",
      },
    ],
  },
};

export default nextConfig;
