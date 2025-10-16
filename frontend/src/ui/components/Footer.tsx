"use client";

export default function Footer() {
  return (
    <footer className="bg-dark text-light py-4 mt-auto">
      <div className="container text-center">
        <p className="mb-2">
          “El diseño no es solo cómo se ve y se siente, es cómo funciona.”
        </p>
        <small className="text-secondary">
          © {new Date().getFullYear()} Sebastian Chaparro
        </small>
      </div>
    </footer>
  );
}
