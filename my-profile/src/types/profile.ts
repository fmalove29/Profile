export type ContactLink = {
  label: string
  value: string
  href: string
}

export type SkillGroup = {
  title: string
  items: string[]
}

export type ExperienceItem = {
  role: string
  company: string
  period: string
  summary: string
  highlights: string[]
  stack: string[]
}

export type EducationItem = {
  level: string
  school: string
  period: string
  details?: string
}

export type ProfileData = {
  name: string
  title: string
  location: string
  phone: string
  email: string
  linkedin: string
  intro: string
  summary: string
  availability: string
  heroImage: string
  accentImage: string
  contactLinks: ContactLink[]
  quickStats: string[]
  skillGroups: SkillGroup[]
  experience: ExperienceItem[]
  education: EducationItem[]
}
