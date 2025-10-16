import "bootstrap/dist/css/bootstrap.min.css";
import "../styles/globals.scss";
import AppNavbar from "@/ui/components/Navbar";
import Footer from "@/ui/components/footer";

export const metadata = {
  title: "Sebastian Chaparro - Prueba Técnica Million",
  description: "Property list with filters",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="es">
      <body className="d-flex flex-column min-vh-100">
        <AppNavbar />
        <main className="flex-grow-1">{children}</main>
        <Footer />
      </body>
    </html>
  );
}
