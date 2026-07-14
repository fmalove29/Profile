import formalPhoto from '../assets/evander-formal.jpg'
import gradPhoto from '../assets/evander-grad.jpg'
import type { ProfileData } from '../types/profile'

export const profile: ProfileData = {
  name: 'Evander Vales',
  title: 'Web Developer',
  location: 'Minglanilla, Cebu',
  phone: '09687069841',
  email: 'evandervales.act2022@gmail.com',
  linkedin: 'https://www.linkedin.com/in/evander-vales-7461a827b/',
  intro: 'Building practical web applications that support real business operations.',
  summary:
    'I am a qualified and professional web developer with hands-on experience in full-stack development, database administration, and enterprise system design. I work comfortably across modern frameworks and SQL-backed systems, with a strong focus on reliability, maintainability, and collaborative delivery.',
  availability: 'Open to full-time web and application development roles',
  heroImage: formalPhoto,
  accentImage: gradPhoto,
  contactLinks: [
    {
      label: 'Call',
      value: '09687069841',
      href: 'tel:09687069841',
    },
    {
      label: 'Email',
      value: 'evandervales.act2022@gmail.com',
      href: 'mailto:evandervales.act2022@gmail.com',
    },
    {
      label: 'LinkedIn',
      value: 'evander-vales-7461a827b',
      href: 'https://www.linkedin.com/in/evander-vales-7461a827b/',
    },
  ],
  quickStats: [
    'Full-stack development',
    'Enterprise application support',
    'Database-driven systems',
    'Agile team collaboration',
  ],
  skillGroups: [
    {
      title: 'Backend & Frameworks',
      items: ['ASP.NET MVC', 'ASP.NET Web API', 'EF Core', 'Laravel', 'PHP'],
    },
    {
      title: 'Programming & Data',
      items: ['C#', 'SQL Server', 'HTML', 'JavaScript', 'CSS'],
    },
    {
      title: 'Strengths',
      items: [
        'System maintenance',
        'Business-critical applications',
        'Cross-team collaboration',
        'Detail-oriented problem solving',
      ],
    },
  ],
  experience: [
    {
      role: 'Applications Developer',
      company: 'Virginia Food Incorporated',
      period: '2023 - Present',
      summary:
        'Supporting enterprise development work and maintaining internal applications aligned with business needs.',
      highlights: [
        'Built and maintained Laravel and PHP-based business applications.',
        'Worked extensively with SQL Server to support operational data flows.',
        'Collaborated with other team sections to deliver and maintain internal solutions.',
      ],
      stack: ['Laravel', 'PHP', 'SQL Server'],
    },
    {
      role: 'Software Engineer Intern',
      company: 'Gemango Software Services',
      period: 'February 2023 - March 2023',
      summary:
        'Contributed to a human resource information system using Microsoft and frontend technologies in an Agile environment.',
      highlights: [
        'Developed features for a Human Resource Information System.',
        'Worked with ASP.NET Web API, C#, EF Core, SQL Server, and Angular.',
        'Practiced Agile methodologies while collaborating inside a delivery team.',
      ],
      stack: ['ASP.NET Web API', 'C#', 'EF Core', 'SQL Server', 'Angular'],
    },
  ],
  education: [
    {
      level: 'Bachelor of Science in Information Technology',
      school: 'Asian College of Technology',
      period: '2019 - 2023',
    },
    {
      level: 'Senior High School',
      school: 'Asian College of Technology',
      period: '2017 - 2019',
    },
    {
      level: 'Secondary School',
      school: 'Naga National High School',
      period: '2013 - 2017',
    },
  ],
}
