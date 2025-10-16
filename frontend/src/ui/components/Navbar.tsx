import Link from "next/link";
import { Navbar } from "react-bootstrap";

export default function AppNavbar() {
  return (
    <Navbar bg="dark" variant="dark" expand="lg" className="shadow-sm">
        <Link href="/" className="navbar-brand fw-bold">
        </Link>
    </Navbar>
  );
}
